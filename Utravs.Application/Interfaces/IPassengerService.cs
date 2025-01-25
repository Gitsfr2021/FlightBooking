using Utravs.Application.Passenger.DTOs;

namespace Utravs.Application.Interfaces
{
    public interface IPassengerService
    {
        Task<(bool IsSuccess, string DuplicateField, long? PassengerId)> CreatePassengerAsync(CreatePassengerDto PassengerDto);
        Task<IEnumerable<PassengerDTO>> GetPassengersAsync(string fullName, string email, string passportNumber);
    }

}
