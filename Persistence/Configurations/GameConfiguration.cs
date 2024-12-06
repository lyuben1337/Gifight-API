using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class GameConfiguration : ApplicationEntityConfiguration<Game>
{
    public override void Configure(EntityTypeBuilder<Game> builder)
    {
        base.Configure(builder);

        builder.Property(g => g.StartedAt)
            .IsRequired();

        builder.Property(g => g.EndedAt)
            .IsRequired(false);

        builder.HasOne(g => g.Deck1)
            .WithMany()
            .HasForeignKey(g => g.Deck1Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(g => g.Deck2)
            .WithMany()
            .HasForeignKey(g => g.Deck2Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(g => g.Winner)
            .WithMany()
            .HasForeignKey(g => g.WinnerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(g => g.Moves)
            .WithOne(m => m.Game)
            .HasForeignKey(m => m.GameId);
    }
}