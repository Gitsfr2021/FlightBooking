using Microsoft.EntityFrameworkCore;
using Utravs.Application.Interfaces;
using Utravs.Core.Entities.CMS;
using Utravs.Infrastructure.Persistence.DbContexts;

namespace Utravs.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _dbContext;

        public FlightRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Flight> CreateAsync(Flight flight)
        {
            _dbContext.Flights.Add(flight);
            await _dbContext.SaveChangesAsync();
            return flight;
        }

        public async Task<Flight?> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Flights.FindAsync(id);
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync(string origin, string destination, DateTime? departureDate)
        {
            var query = _dbContext.Flights.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(origin))
                query = query.Where(f => f.Origin == origin);

            if (!string.IsNullOrWhiteSpace(destination))
                query = query.Where(f => f.Destination == destination);

            if (departureDate!=null)
                query = query.Where(f => f.DepartureTime.Date == departureDate.Value.Date);

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Flight flight)
        {
            _dbContext.Flights.Update(flight);
            await _dbContext.SaveChangesAsync();
        }
    }

}
