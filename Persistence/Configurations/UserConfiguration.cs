using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.EncryptedPassword)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .IsRequired()
            .HasDefaultValue(UserRole.Player);

        builder.HasMany(u => u.Cards)
            .WithMany(c => c.Users)
            .UsingEntity<UserCard>();

        builder.HasIndex(u => u.Username)
            .IsUnique();
    }
}