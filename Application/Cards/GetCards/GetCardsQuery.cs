using Application.Shared.Messaging;

namespace Application.Cards.GetCards;

public record GetCardsQuery(
    int Page = 1,
    int PageSize = 0
) : IQuery<GetCardsQueryResponse>;