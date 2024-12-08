using FluentValidation;

namespace Application.Users.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(255)
            .Matches(@"^[a-zA-Z0-9]+$")
            .WithMessage("Username can only contain English letters and numbers");

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255)
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-_]).{8,}$")
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character");
    }
}