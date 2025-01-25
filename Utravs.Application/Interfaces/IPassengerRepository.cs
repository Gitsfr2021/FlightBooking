using System.Linq.Expressions;
using Utravs.Core.Entities.CMS;

namespace Utravs.Application.Interfaces
{
    public interface IPassengerRepository
    {
        Task<Utravs.Core.Entities.CMS.Passenger> CreateAsync(Utravs.Core.Entities.CMS.Passenger Passenger);
        Task<Utravs.Core.Entities.CMS.Passenger> GetByIdAsync(Int64 id);
        Task<IEnumerable<Utravs.Core.Entities.CMS.Passenger>> GetPassengersAsync(string fullName, string email, string passportNumber);
        Task<bool> ExistsAsync(Expression<Func<Utravs.Core.Entities.CMS.Passenger, bool>> predicate);

    }

}
