using MediatR;
using Utravs.Application.Passenger.DTOs;

namespace Utravs.Application.Passenger.Commands
{
    public class CreatePassengerResult
    {
        public bool IsSuccess { get; set; }
        public string? DuplicateField { get; set; }
        public long? PassengerId { get; set; }
    }
    public class CreatePassengerCommand : IRequest<CreatePassengerResult>
    {
        public CreatePassengerDto PassengerDto { get; set; }
        public CreatePassengerCommand(CreatePassengerDto passengerDto)
        {
            PassengerDto = passengerDto;
        }
    }
}
