using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Utravs.Application.Interfaces;
using Utravs.Core.Entities.CMS;
using Utravs.Infrastructure.Persistence.DbContexts;

namespace Utravs.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AppDbContext _dbContext;

        public PassengerRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Passenger> CreateAsync(Passenger Passenger)
        {
            _dbContext.Passengers.Add(Passenger);
            await _dbContext.SaveChangesAsync();
            return Passenger;
        }

        public async Task<Passenger?> GetByIdAsync(Int64 id)
        {
            return await _dbContext.Passengers.FindAsync(id);
        }

        public async Task<IEnumerable<Passenger>> GetPassengersAsync(string fullName, string email, string passportNumber)
        {
            var query = _dbContext.Passengers.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(fullName))
                query = query.Where(f => f.FullName.Contains(fullName));

            if (!string.IsNullOrWhiteSpace(email))
                query = query.Where(f => f.Email == email);

            if (!string.IsNullOrWhiteSpace (passportNumber))
                query = query.Where(f => f.PassportNumber == passportNumber);

            return await query.ToListAsync();
        }
        public async Task<bool> ExistsAsync(Expression<Func<Passenger, bool>> predicate)
        {
            return await _dbContext.Passengers.AnyAsync(predicate);
        }


    }

}
