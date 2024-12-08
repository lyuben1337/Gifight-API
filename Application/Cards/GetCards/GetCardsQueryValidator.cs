using FluentValidation;

namespace Application.Cards.GetCards;

public class GetCardsQueryValidator : AbstractValidator<GetCardsQuery>
{
    public GetCardsQueryValidator()
    {
        RuleFor(q => q.Page)
            .GreaterThanOrEqualTo(1);

        RuleFor(q => q.PageSize)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100);
    }
}