using FluentValidation;
using System.Linq.Expressions;
using FluentValidation;

namespace Utravs.Application.Validation
{
    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        protected void ValidateRequiredString(Expression<Func<T, string>> expression, int maxLength, string fieldName)
        {
            RuleFor(expression)
                .NotEmpty().WithMessage($"{fieldName} is required.")
                .MaximumLength(maxLength).WithMessage($"{fieldName} cannot exceed {maxLength} characters.");
        }

        protected void ValidateEmail(Expression<Func<T, string>> expression)
        {
            RuleFor(expression)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }

        protected void ValidateOptionalString(Expression<Func<T, string>> expression, int maxLength, string fieldName)
        {
            RuleFor(expression)
                .MaximumLength(maxLength).WithMessage($"{fieldName} cannot exceed {maxLength} characters.");
        }
    }

}
