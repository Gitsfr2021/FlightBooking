using MediatR;
using Utravs.Application.Passenger.Commands;
using Utravs.Application.Interfaces;
using FluentValidation;
using Utravs.Application.Passenger.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Utravs.Application.Handlers
{
    public class CreatePassengerCommandHandler : IRequestHandler<CreatePassengerCommand, CreatePassengerResult>
    {
        private readonly IPassengerService _PassengerService;
        private readonly IValidator<CreatePassengerDto> _validator;
        public CreatePassengerCommandHandler(IPassengerService passengerService, IValidator<CreatePassengerDto> validator)
        {
            _PassengerService = passengerService;
            _validator = validator;
        }

        public async Task<CreatePassengerResult> Handle(CreatePassengerCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.PassengerDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new FluentValidation.ValidationException(validationResult.Errors);
            }
            var result = await _PassengerService.CreatePassengerAsync(request.PassengerDto);

            return new CreatePassengerResult
            {
                IsSuccess = result.IsSuccess,
                DuplicateField = result.DuplicateField,
                PassengerId = result.PassengerId
            };
        }
    }


}
