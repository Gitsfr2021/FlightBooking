using Utravs.Application.Booking.DTOs;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _fligtRepository;
        private readonly SemaphoreSlim _initializationLock = new SemaphoreSlim(1, 1); 
        private SemaphoreSlim _semaphore;

        private async Task InitializeSemaphoreAsync(long flightId)
        {
            if (_semaphore == null)
            {
                await _initializationLock.WaitAsync(); 
                try
                {
                    if (_semaphore == null) 
                    {
                        var flight = await _fligtRepository.GetByIdAsync(flightId); 
                        if (flight == null)
                        {
                            throw new InvalidOperationException("Flight not found."); 
                        }
                     
                        _semaphore = new SemaphoreSlim(flight.AvailableSeats, flight.AvailableSeats);
                    }
                }
                finally
                {
                    _initializationLock.Release(); 
                }
            }
        }
        public BookingService(IBookingRepository bookingRepository, IFlightRepository fligtRepository)
        {
            _bookingRepository = bookingRepository;
            _fligtRepository = fligtRepository;
        }

        public async Task<bool> CreateBookingAsync(BookingDTO bookingDto)
        {
            await InitializeSemaphoreAsync(bookingDto.FlightId);
           
            await _semaphore.WaitAsync();

            try
            {
                // check flight
                var flight = await _fligtRepository.GetByIdAsync(bookingDto.FlightId);
                if (flight == null)
                    throw new InvalidOperationException("Flight not found.");

                // check available seats
                if (flight.AvailableSeats <= 0)
                    throw new InvalidOperationException("No available seats for this flight.");

                // check reserve seat
                var existingBooking = await _bookingRepository.GetBookingByFlightAndSeatAsync(bookingDto.FlightId, bookingDto.SeatNumber);
                if (existingBooking != null)
                    throw new InvalidOperationException($"Seat {bookingDto.SeatNumber} is already booked for this flight.");

                flight.AvailableSeats--;

                //  update seat
                await _fligtRepository.UpdateAsync(flight);


                var booking = new BookingDTO
                {
                    FlightId = bookingDto.FlightId,
                    PassengerId = bookingDto.PassengerId,
                    BookingDate = DateTime.Now,
                    SeatNumber = bookingDto.SeatNumber
                };

                // create reserve
                await _bookingRepository.CreateBookingAsync(booking);

                return true;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while creating the booking.", ex);
            }
            finally
            {
                _semaphore.Release();
            }
        }
        public async Task<List<BookingDTO>> GetBookingsWithLazyLoadingAsync(long flightId)
        {
            var bookings = await _bookingRepository.GetBookingsByFlightIdAsync(flightId);

            foreach (var booking in bookings)
            {
                var passengerName = booking.PassengerName;
            }

            //var passengerNames = await _bookingRepository.GetBookingsByFlightIdAsync(flightId).Select(booking => booking.PassengerName).ToListAsync();
            //var tasks = bookings.Select(async booking =>
            //{
            //    var passengerName = booking.PassengerName;
            //    await SomeAsyncOperation(booking);
            //}).ToList();
            /////await Task.WhenAll(tasks);
            return bookings;
        }
    }

}
