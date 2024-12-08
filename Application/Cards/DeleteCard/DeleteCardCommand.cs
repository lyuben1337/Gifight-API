using Application.Shared.Messaging;
using MediatR;

namespace Application.Cards.DeleteCard;

public record DeleteCardCommand(
    long Id
) : ICommand<Unit>;