namespace Utravs.Application.Flights.DTOs
{
    public class UpdateSeatsDto
    {
        public Int64 FlightId { get; set; }
        public int SeatsToAdd { get; set; }
    }
}
