using Application.Shared.Messaging;
using MediatR;

namespace Application.Cards.UpdateCard;

public record UpdateCardCommand(
    long Id,
    string Title,
    string ImageUrl,
    int Power
) : ICommand<Unit>;

public record UpdateCardRequest(
    string Title,
    string ImageUrl,
    int Power
);