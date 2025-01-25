using Utravs.Application.Booking.DTOs;

namespace Utravs.Application.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(BookingDTO bookingDto);
    }

}
