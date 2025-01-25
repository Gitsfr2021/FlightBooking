using MediatR;
using Utravs.Application.Flights.Commands;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Handlers
{
    public class UpdateAvailableSeatsCommandHandler : IRequestHandler<UpdateAvailableSeatsCommand, bool>
    {
        private readonly IFlightRepository _flightRepository;

        public UpdateAvailableSeatsCommandHandler(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task<bool> Handle(UpdateAvailableSeatsCommand request, CancellationToken cancellationToken)
        {
            var flight = await _flightRepository.GetByIdAsync(request.FlightId);

            if (flight == null) return false;

            flight.AvailableSeats += request.SeatsToAdd;
            await _flightRepository.UpdateAsync(flight);

            return true;
        }
    }

}
