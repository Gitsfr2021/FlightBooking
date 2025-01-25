using Utravs.Application.Booking.DTOs;

namespace Utravs.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> CreateBookingAsync(BookingDTO bookingDto);
        Task<List<BookingDTO>> GetBookingsByFlightIdAsync(long flightId);
    }
}
