using Domain.Shared;

namespace Domain.Entities;

public class Deck : ApplicationEntity
{
    public required Game Game { get; set; }
    public required long GameId { get; set; }
    public required User Player { get; set; }
    public required long PlayerId { get; set; }
    public required List<DeckCard> DeckCards { get; set; }
}