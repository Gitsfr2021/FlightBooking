using Utravs.Core.Entities.CMS;

namespace Utravs.Application.Interfaces
{
    public interface IFlightRepository
    {
        Task<Flight> CreateAsync(Flight flight);
        Task<Flight> GetByIdAsync(Int64 id);
        Task<IEnumerable<Flight>> GetFlightsAsync(string origin, string destination, DateTime? departureDate);
        Task UpdateAsync(Flight flight);
    }

}
