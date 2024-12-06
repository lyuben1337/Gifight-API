using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class MoveConfiguration : ApplicationEntityConfiguration<Move>
{
    public override void Configure(EntityTypeBuilder<Move> builder)
    {
        base.Configure(builder);

        builder.HasOne(m => m.Game)
            .WithMany()
            .HasForeignKey(m => m.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Deck)
            .WithMany()
            .HasForeignKey(m => m.DeckId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Card)
            .WithMany()
            .HasForeignKey(m => m.CardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}