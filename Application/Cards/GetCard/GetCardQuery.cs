using Application.Shared.Messaging;

namespace Application.Cards.GetCard;

public record GetCardQuery(
    long Id
) : IQuery<GetCardQueryResponse>;