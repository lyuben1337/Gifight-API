using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Shared;

namespace Persistence.Configurations;

public class UserCardConfiguration : BaseEntityConfiguration<UserCard>
{
    public override void Configure(EntityTypeBuilder<UserCard> builder)
    {
        base.Configure(builder);

        builder.HasOne(uc => uc.User)
            .WithMany(u => u.UserCards)
            .HasForeignKey(uc => uc.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(uc => uc.Card)
            .WithMany(c => c.UserCards)
            .HasForeignKey(c => c.CardId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}