using MediatR;
using Utravs.Application.Booking.DTOs;
using Utravs.Application.Booking.Queries;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Handlers
{
    public class GetBookingsByFlightQueryHandler : IRequestHandler<GetBookingsByFlightQuery, List<BookingDTO>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingsByFlightQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<List<BookingDTO>> Handle(GetBookingsByFlightQuery request, CancellationToken cancellationToken)
        {
            return await _bookingRepository.GetBookingsByFlightIdAsync(request.FlightId);
        }
    }
}
