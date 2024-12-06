using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class DeckConfiguration : ApplicationEntityConfiguration<Deck>
{
    public override void Configure(EntityTypeBuilder<Deck> builder)
    {
        base.Configure(builder);

        builder.Property(d => d.GameId)
            .IsRequired();

        builder.HasOne(d => d.Player)
            .WithMany()
            .HasForeignKey(d => d.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(d => d.DeckCards)
            .WithOne(dc => dc.Deck)
            .HasForeignKey(dc => dc.DeckId);
    }
}