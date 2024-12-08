using Application.Shared.Messaging;

namespace Application.Cards.CreateCard;

public record CreateCardCommand(
    string Title,
    string ImageUrl,
    int Power
) : ICommand<CreateCardCommandResponse>;