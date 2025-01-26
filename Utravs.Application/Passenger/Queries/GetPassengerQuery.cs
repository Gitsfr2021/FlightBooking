using MediatR;
using Utravs.Application.Passenger.DTOs;

namespace Utravs.Application.Passenger.Queries
{
    public class GetPassengerQuery : IRequest<IEnumerable<PassengerDTO>>
    {
        public string? FullName { get; set; } 
        public string? Email { get; set; } 
        public string? PassportNumber { get; set; } 
        public string? PhoneNumber { get; set; }
    }
}
