using Domain.Shared;

namespace Domain.Entities;

public class Deck : ApplicationEntity
{
    public required long GameId { get; set; }
    public required User Player { get; set; }
    public required List<DeckCard> Cards { get; set; }
}