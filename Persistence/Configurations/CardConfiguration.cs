using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class CardConfiguration : BaseEntityConfiguration<Card>
{
    public override void Configure(EntityTypeBuilder<Card> builder)
    {
        base.Configure(builder);

        builder.Property(c => c.Title)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(c => c.ImageUrl)
            .IsRequired()
            .HasMaxLength(2048);

        builder.Property(c => c.Power)
            .IsRequired();

        builder.HasIndex(u => u.Title)
            .IsUnique();
    }
}