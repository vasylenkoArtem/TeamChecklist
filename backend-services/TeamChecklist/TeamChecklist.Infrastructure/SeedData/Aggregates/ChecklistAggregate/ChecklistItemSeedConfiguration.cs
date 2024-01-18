using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Infrastructure.SeedData.Aggregates.ChecklistAggregate;

public class ChecklistItemSeedConfiguration
    : IEntityTypeConfiguration<ChecklistItem>
{
    
    public void Configure(EntityTypeBuilder<ChecklistItem> builder)
    {
        Seed(builder);
    }

    public static void Seed(EntityTypeBuilder<ChecklistItem> builder)
    {
        builder.HasData(new List<ChecklistItem>()
        {
            new ChecklistItem()
            {
                ChecklistId = Guid.Parse("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                Id = Guid.Parse("279d04dd-53ac-432d-a906-5e6a2de8c3ff"),
                Status = ChecklistItemStatus.ToDo,
                TextDescription = "Turn on kitchen ventilation"
            },
            new ChecklistItem()
            {
                ChecklistId = Guid.Parse("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                Id = Guid.Parse("2ad1560f-5f23-40ac-ae70-b6b4c6cbcd1d"),
                Status = ChecklistItemStatus.ToDo,
                TextDescription = "Turn on the coffee machine power supply"
            },
            new ChecklistItem()
            {
                ChecklistId = Guid.Parse("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                Id = Guid.Parse("b31615ce-3a2e-4c50-8a77-d993437a74e5"),
                Status = ChecklistItemStatus.ToDo,
                TextDescription = "Start unfreezing semi-finished products from freezer"
            },
            new ChecklistItem()
            {
                ChecklistId = Guid.Parse("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                Id = Guid.Parse("9132432e-b53c-4a1f-bb8c-8124194ab9e0"),
                Status = ChecklistItemStatus.ToDo,
                TextDescription = "Prepare cups"
            },
            new ChecklistItem()
            {
                ChecklistId = Guid.Parse("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                Id = Guid.Parse("2c872939-d57e-4c11-bdd7-5312378184b8"),
                Status = ChecklistItemStatus.ToDo,
                TextDescription = "Turn on kitchen ventilation"
            },
        });
    }
}