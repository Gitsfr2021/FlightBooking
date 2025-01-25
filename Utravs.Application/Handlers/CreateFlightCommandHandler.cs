using MediatR;
using Utravs.Application.Flights.Commands;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Handlers
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Int64>
    {
        private readonly IFlightService _flightService;

        public CreateFlightCommandHandler(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<Int64> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            return await _flightService.CreateFlightAsync(request.FlightDto);
        }
    }

}
