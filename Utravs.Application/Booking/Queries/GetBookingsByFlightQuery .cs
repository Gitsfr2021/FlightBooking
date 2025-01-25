using MediatR;
using Utravs.Application.Booking.DTOs;

namespace Utravs.Application.Booking.Queries
{
    public class GetBookingsByFlightQuery : IRequest<List<BookingDTO>>
    {
        public long FlightId { get; set; }
    }
}
