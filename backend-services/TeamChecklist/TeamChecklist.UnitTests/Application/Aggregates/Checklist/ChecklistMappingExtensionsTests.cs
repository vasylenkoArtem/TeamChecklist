using TeamChecklist.Application.Aggregates.Checklist.Mapping;
using TeamChecklist.Domain.ChecklistAggregate;
using Xunit;

namespace TeamChecklist.UnitTests.Application.Aggregates.Checklist;

public class ChecklistMappingExtensionsTests
{
    [Fact]
    public void Checklist_Map_Returns_Correct_Dto()
    {
        // Arrange
        var checklist = new TeamChecklist.Domain.ChecklistAggregate.Checklist
        {
            Id = Guid.NewGuid(),
            Status = CheckListStatus.Done,
            CompletedDate = DateTime.Now,
            Items = new List<ChecklistItem>
            {
                new ChecklistItem
                {
                    Id = Guid.NewGuid(),
                    TextDescription = "Item 1",
                    Status = ChecklistItemStatus.ToDo,
                    CompletedBy = null
                },
                new ChecklistItem
                {
                    Id = Guid.NewGuid(),
                    TextDescription = "Item 2",
                    Status = ChecklistItemStatus.Done,
                    CompletedBy = Guid.NewGuid()
                }
            }
        };

        // Act
        var dto = checklist.Map();

        // Assert
        Assert.Equal(checklist.Id, dto.Id);
        Assert.Equal(checklist.Status, dto.Status);
        Assert.Equal(checklist.CompletedDate, dto.CompletedDate);
        Assert.Equal(checklist.Items.Count, dto.Items.Count);
        // Additional assertions for item properties
        for (int i = 0; i < checklist.Items.Count; i++)
        {
            Assert.Equal(checklist.Items[i].Id, dto.Items[i].Id);
            Assert.Equal(checklist.Items[i].TextDescription, dto.Items[i].TextDescription);
            Assert.Equal(checklist.Items[i].Status, dto.Items[i].Status);
        }
    }

    [Fact]
    public void ChecklistItem_Map_Returns_Correct_Dto()
    {
        // Arrange
        var checklistItem = new ChecklistItem
        {
            Id = Guid.NewGuid(),
            TextDescription = "Test Item",
            Status = ChecklistItemStatus.Done,
            CompletedBy = Guid.NewGuid()
        };

        // Act
        var dto = checklistItem.Map();

        // Assert
        Assert.Equal(checklistItem.Id, dto.Id);
        Assert.Equal(checklistItem.TextDescription, dto.TextDescription);
        Assert.Equal(checklistItem.Status, dto.Status);
    }
}