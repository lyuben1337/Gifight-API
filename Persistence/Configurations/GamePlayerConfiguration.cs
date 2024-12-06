using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class GamePlayerConfiguration : ApplicationEntityConfiguration<GamePlayer>
{
    public override void Configure(EntityTypeBuilder<GamePlayer> builder)
    {
        base.Configure(builder);

        builder.HasOne(gp => gp.Game)
            .WithMany(g => g.GamePlayers)
            .HasForeignKey(gp => gp.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(gp => gp.Player)
            .WithMany()
            .HasForeignKey(gp => gp.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}