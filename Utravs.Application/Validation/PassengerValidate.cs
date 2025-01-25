using FluentValidation;
using Utravs.Application.Passenger.DTOs;

namespace Utravs.Application.Validation
{
    public class CreatePassengerCommandValidator : AbstractValidator<CreatePassengerDto>
    {
        public CreatePassengerCommandValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(p => p.PassportNumber).NotEmpty().WithMessage("Passport Number is required.").MaximumLength(20).WithMessage("Passport Number cannot exceed 20 characters.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.").Matches(@"^09\d{9}$").WithMessage("Invalid phone number format.");
        }
    }
}
