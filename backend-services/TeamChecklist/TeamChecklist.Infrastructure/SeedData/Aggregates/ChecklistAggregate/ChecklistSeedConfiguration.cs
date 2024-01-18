using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Infrastructure.SeedData.Aggregates.ChecklistAggregate;

public class ChecklistSeedConfiguration
    : IEntityTypeConfiguration<Checklist>
{
    public void Configure(EntityTypeBuilder<Checklist> builder)
    {
        builder.HasData(new List<Checklist>()
        {
            new Checklist()
            {
                Id = Guid.Parse("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                Status = CheckListStatus.ToDo,
                Type = ChecklistType.Morning,
                CompletedDate = null
            }
        });
    }
}