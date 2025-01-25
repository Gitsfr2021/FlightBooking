using Utravs.Application.Passenger.DTOs;
using Utravs.Application.Interfaces;
using Utravs.Core.Entities.CMS;

namespace Utravs.Application.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _PassengerRepository;

        public PassengerService(IPassengerRepository PassengerRepository)
        {
            _PassengerRepository = PassengerRepository;
        }

        public async Task<(bool IsSuccess, string DuplicateField, long? PassengerId)> CreatePassengerAsync(CreatePassengerDto passengerDto)
        {
           
            if (await _PassengerRepository.ExistsAsync(p => p.Email == passengerDto.Email))
            {
                return (false, "Email", null);
            }

            if (await _PassengerRepository.ExistsAsync(p => p.FullName == passengerDto.FullName))
            {
                return (false, "FullName", null);
            }

            if (await _PassengerRepository.ExistsAsync(p => p.PassportNumber == passengerDto.PassportNumber))
            {
                return (false, "PassportNumber", null);
            }

        
            var passenger = new Core.Entities.CMS.Passenger
            {
                Email = passengerDto.Email,
                FullName = passengerDto.FullName,
                PassportNumber = passengerDto.PassportNumber,
                PhoneNumber = passengerDto.PhoneNumber,
            };

            var createdPassenger = await _PassengerRepository.CreateAsync(passenger);
            return (true, null, createdPassenger.Id);
        }

        public async Task<IEnumerable<PassengerDTO>> GetPassengersAsync(string fullName, string email, string passportNumber)
        {
            var Passengers = await _PassengerRepository.GetPassengersAsync(fullName, email, passportNumber);
            return Passengers.Select(f => new PassengerDTO
            {
                Id = f.Id,
                Email = f.Email,
                FullName = f.FullName,
                PassportNumber = f.PassportNumber,
                PhoneNumber = f.PhoneNumber

            });
        }

     
    }

}
