using FluentValidation;

namespace Application.Users.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.CardIds)
            .NotEmpty();
    }
}