using FluentValidation;
using UsersMicroService.Core.Dtos;

namespace UsersMicroService.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address structure");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}
