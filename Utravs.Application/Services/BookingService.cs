using Utravs.Application.Booking.DTOs;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<bool> CreateBookingAsync(BookingDTO bookingDto)
        {
            await _semaphore.WaitAsync(); 

            try
            {
                return await _bookingRepository.CreateBookingAsync(bookingDto);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

}
