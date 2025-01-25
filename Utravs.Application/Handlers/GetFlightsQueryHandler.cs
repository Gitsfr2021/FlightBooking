using MediatR;
using Utravs.Application.Flights.DTOs;
using Utravs.Application.Flights.Queries;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Handlers
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, IEnumerable<FlightDto>>
    {
        private readonly IFlightService _flightService;

        public GetFlightsQueryHandler(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<IEnumerable<FlightDto>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            return await _flightService.GetFlightsAsync(request.Origin, request.Destination, request.DepartureDate);
        }
    }

}
