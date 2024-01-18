using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChecklist.Domain.UserAggregate;

namespace TeamChecklist.Infrastructure.Aggregates.UserAggregate;

public class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("newsequentialid()");

        builder.Property(x => x.Username)
            .IsRequired(true)
            .HasMaxLength(300);
    }
}