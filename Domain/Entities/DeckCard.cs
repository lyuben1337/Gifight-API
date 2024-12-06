using Domain.Shared;

namespace Domain.Entities;

public class DeckCard : ApplicationEntity
{
    public required long DeckId { get; set; }
    public required Deck Deck { get; set; }
    public required long CardId { get; set; }
    public required Card Card { get; set; }
}