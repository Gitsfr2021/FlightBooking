using MediatR;

namespace Utravs.Application.Flights.Commands
{
    public class UpdateAvailableSeatsCommand : IRequest<bool>
    {
        public Int64 FlightId { get; set; }
        public int SeatsToAdd { get; set; }
    }
}
