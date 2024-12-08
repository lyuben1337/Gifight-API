using FluentValidation;

namespace Application.Auth.SignUp;

public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(255)
            .Matches(@"^[a-zA-Z0-9]+$")
            .WithMessage("Username can only contain English letters and numbers")
            .Must(username => !IsForbiddenUsername(username))
            .WithMessage("Username cannot be 'admin', 'superuser', or other restricted names.");
        ;

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(255)
            .Matches(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-_]).{8,}$")
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character"
            );
    }

    private bool IsForbiddenUsername(string username)
    {
        var forbiddenUsernames = new[] { "admin", "superuser", "root", "administrator" };
        return forbiddenUsernames.Contains(username.ToLower());
    }
}