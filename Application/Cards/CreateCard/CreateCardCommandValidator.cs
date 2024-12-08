using FluentValidation;

namespace Application.Cards.CreateCard;

public class CreateCardCommandValidator : AbstractValidator<CreateCardCommand>
{
    public CreateCardCommandValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(255)
            .WithMessage("Title must be between 3 and 255 characters");

        RuleFor(c => c.ImageUrl)
            .NotEmpty()
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute));

        RuleFor(c => c.Power)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);
    }
}