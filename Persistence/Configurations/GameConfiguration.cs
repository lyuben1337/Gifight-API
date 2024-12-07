using Domain.Entities;
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
            .IsRequired();

        builder.HasMany(g => g.Players)
            .WithMany()
            .UsingEntity<GamePlayer>();
    }
}