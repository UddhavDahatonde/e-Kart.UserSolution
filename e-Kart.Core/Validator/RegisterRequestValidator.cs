using e_Kart.Core.DTO;
using FluentValidation;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x.PersonName).NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name must be less than 50 character.");

        RuleFor(x => x.GenderOption).IsInEnum().WithMessage("Invalid gender options.");
    }
}

