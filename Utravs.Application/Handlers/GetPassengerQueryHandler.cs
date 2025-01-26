using MediatR;
using Utravs.Application.Passenger.DTOs;
using Utravs.Application.Passenger.Queries;
using Utravs.Application.Interfaces;

namespace Utravs.Application.Handlers
{
    public class GetPassengerQueryHandler : IRequestHandler<GetPassengerQuery, IEnumerable<PassengerDTO>>
    {
        private readonly IPassengerService _PassengerService;

        public GetPassengerQueryHandler(IPassengerService Passengerervice)
        {
            _PassengerService = Passengerervice;
        }

        public async Task<IEnumerable<PassengerDTO>> Handle(GetPassengerQuery request, CancellationToken cancellationToken)
        {
            return await _PassengerService.GetPassengersAsync(request.FullName, request.Email, request.PassportNumber);
        }
    }

}
