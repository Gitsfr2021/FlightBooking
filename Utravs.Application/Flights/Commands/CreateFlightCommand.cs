using MediatR;
using Utravs.Application.Flights.DTOs;

namespace Utravs.Application.Flights.Commands
{
    public class CreateFlightCommand : IRequest<Int64>
    {
        public CreateFlightDto FlightDto { get; set; }
    }
}
