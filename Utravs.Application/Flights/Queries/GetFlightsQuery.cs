using MediatR;
using Utravs.Application.Flights.DTOs;

namespace Utravs.Application.Flights.Queries
{
    public class GetFlightsQuery : IRequest<IEnumerable<FlightDto>>
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime? DepartureDate { get; set; }
    }
}
