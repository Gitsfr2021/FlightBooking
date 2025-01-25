using Utravs.Application.Flights.DTOs;

namespace Utravs.Application.Interfaces
{
    public interface IFlightService
    {
        Task<Int64> CreateFlightAsync(CreateFlightDto flightDto);
        Task<IEnumerable<FlightDto>> GetFlightsAsync(string origin, string destination, DateTime? departureDate);
        Task<bool> UpdateAvailableSeatsAsync(UpdateSeatsDto updateSeatsDto);
    }
}
