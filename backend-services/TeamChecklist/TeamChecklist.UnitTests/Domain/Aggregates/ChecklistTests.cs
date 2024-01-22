using FluentAssertions;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Domain.Exceptions;
using Xunit;

namespace TeamChecklist.UnitTests.Domain.Aggregates;

public class ChecklistTests
{
    [Fact]
    public void MarkItemAsDone_ValidItemId_ItemMarkedAsDone()
    {
        // Arrange
        var checklist = new Checklist();
        var item = new ChecklistItem { Id = Guid.NewGuid() };
        checklist.Items.Add(item);

        // Act
        var result = checklist.MarkItemAsDone(item.Id);

        // Assert
        result.Status.Should().Be(ChecklistItemStatus.Done);
    }

    [Fact]
    public void MarkItemAsDone_AllItemsDone_ChecklistMarkedAsDone()
    {
        // Arrange
        var lastItemId = Guid.NewGuid();
        
        var checklist = new Checklist()
        {
          Status  = CheckListStatus.ToDo,
          Items = new List<ChecklistItem>()
          {
              new ChecklistItem()
              {
                  Status = ChecklistItemStatus.Done
              },
              new ChecklistItem()
              {
                  Status = ChecklistItemStatus.ToDo,
                  Id = lastItemId
              },
          }
        };
    
        // Act
        checklist.MarkItemAsDone(lastItemId);

        // Assert
        checklist.Status.Should().Be(CheckListStatus.Done);
        checklist.CompletedDate.Should().NotBeNull();
    }
    
    [Fact]
    public void ResetChecklist_ResetsStatusAndCompletedDateAndItemStatuses()
    {
        // Arrange
        var checklist = new Checklist
        {
            Items = new List<ChecklistItem>
            {
                new ChecklistItem { Status = ChecklistItemStatus.Done },
                new ChecklistItem { Status = ChecklistItemStatus.ToDo }
            },
            Status = CheckListStatus.InProgress,
            CompletedDate = DateTime.Now
        };

        // Act
        checklist.ResetChecklist();

        // Assert
        checklist.Status.Should().Be(CheckListStatus.ToDo);
        checklist.CompletedDate.Should().BeNull();
        checklist.Items.Should().OnlyContain(item => item.Status == ChecklistItemStatus.ToDo);
    }
    
    [Fact]
    public void MarkItemAsDone_ItemDoesNotExist_ThrowsDomainException()
    {
        // Arrange
        var checklist = new Checklist();
        var nonExistentItemId = Guid.NewGuid();

        // Act
        Action act = () => checklist.MarkItemAsDone(nonExistentItemId);

        // Assert
        act.Should().Throw<DomainException>()
            .WithMessage($"ChecklistItem with id {nonExistentItemId} is not found");
    }



}