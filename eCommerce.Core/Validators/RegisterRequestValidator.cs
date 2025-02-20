using eCommerce.Core.Dtos;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address structure");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");

        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("PersonName is required");

        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Given value is not part of gender selection");
    }
}
