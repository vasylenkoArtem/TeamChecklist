using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Domain.UserAggregate;

namespace TeamChecklist.Infrastructure.SeedData.Aggregates.UserAggregate;

public class UserSeedConfiguration
    : IEntityTypeConfiguration<User>
{
    
    public void Configure(EntityTypeBuilder<User> builder)
    {
        Seed(builder);
    }

    public static void Seed(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new List<User>()
        {
            new User()
            {
                Id = Guid.Parse("7a77b40c-30ec-4d3b-b804-afdc34263f9b"),
                Username = "TestUserName"
            }
        });
    }
}