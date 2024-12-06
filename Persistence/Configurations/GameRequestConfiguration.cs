using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class GameRequestConfiguration : ApplicationEntityConfiguration<GameRequest>
{
    public override void Configure(EntityTypeBuilder<GameRequest> builder)
    {
        base.Configure(builder);
    }
}