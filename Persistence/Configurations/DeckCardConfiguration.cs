using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class DeckCardConfiguration : ApplicationEntityConfiguration<DeckCard>
{
    public override void Configure(EntityTypeBuilder<DeckCard> builder)
    {
        base.Configure(builder);

        builder.HasOne(dc => dc.Deck)
            .WithMany(d => d.DeckCards)
            .HasForeignKey(dc => dc.DeckId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(dc => dc.Card)
            .WithMany()
            .HasForeignKey(dc => dc.CardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}