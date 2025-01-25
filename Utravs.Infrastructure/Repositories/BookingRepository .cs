using Microsoft.EntityFrameworkCore;
using Utravs.Application.Booking.DTOs;
using Utravs.Application.Interfaces;
using Utravs.Core.Entities.CMS;
using Utravs.Infrastructure.Persistence.DbContexts;

namespace Utravs.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateBookingAsync(BookingDTO bookingDto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var flight = await _context.Flights.FindAsync(bookingDto.FlightId);

                if (flight == null || flight.AvailableSeats <= 0)
                    return false;

                // update seat
                flight.AvailableSeats--;

                // Booking
                var booking = new Booking
                {
                    FlightId = bookingDto.FlightId,
                    PassengerId = bookingDto.PassengerId,
                    BookingDate = DateTime.Now,
                    SeatNumber = bookingDto.SeatNumber
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<BookingDTO>> GetBookingsByFlightIdAsync(long flightId)
        {
            return await _context.Bookings
                .Where(b => b.FlightId == flightId)
                .Select(b => new BookingDTO
                {
                    Id = b.Id,
                    FlightId = b.FlightId,
                    PassengerId = b.PassengerId,
                    BookingDate = b.BookingDate,
                    SeatNumber = b.SeatNumber
                }).ToListAsync();
        }
    }

}
