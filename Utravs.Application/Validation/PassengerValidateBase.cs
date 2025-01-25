using FluentValidation;
using Utravs.Application.Passenger.Commands;
using Utravs.Application.Passenger.DTOs;

namespace Utravs.Application.Validation
{
    public class CreatePassengerCommandValidatorBase : BaseValidator<CreatePassengerDto>
    {
        public CreatePassengerCommandValidatorBase()
        {
            ValidateRequiredString(p => p.FullName, 100, "Full Name");
            ValidateEmail(p => p.Email);
            ValidateRequiredString(p => p.PassportNumber, 20, "Passport Number");
            ValidateOptionalString(p => p.PhoneNumber, 15, "Phone Number");
        }
    }

}
