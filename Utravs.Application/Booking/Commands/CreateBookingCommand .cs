using MediatR;
using Utravs.Application.Booking.DTOs;

namespace Utravs.Application.Booking.Commands
{
    public class CreateBookingCommand : IRequest<bool>
    {
        public BookingDTO BookingDto { get; set; }
    }
}
