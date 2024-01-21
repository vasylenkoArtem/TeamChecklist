using Xunit;
using Moq;
using System;
using System.Threading;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Domain.ChecklistAggregate;

public class MarkChecklistItemAsDoneCommandHandlerTests
{
    private readonly Mock<IChecklistRepository> _mockChecklistRepository;
    private readonly MarkChecklistItemAsDoneCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public MarkChecklistItemAsDoneCommandHandlerTests()
    {
        _mockChecklistRepository = new Mock<IChecklistRepository>();
        _handler = new MarkChecklistItemAsDoneCommandHandler(_mockChecklistRepository.Object);
        _cancellationToken = new CancellationToken();
    }

    [Fact]
    public async Task Handle_ShouldCallGetByIdOnce()
    {
        // Arrange
        var command = new MarkChecklistItemAsDoneCommand
            { CheckListId = Guid.NewGuid(), CheckListItemId = Guid.NewGuid() };
        _mockChecklistRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new Checklist());

        // Act
        await _handler.Handle(command, _cancellationToken);

        // Assert
        _mockChecklistRepository.Verify(x => x.GetById(command.CheckListId), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesOnce()
    {
        // Arrange
        var command = new MarkChecklistItemAsDoneCommand
            { CheckListId = Guid.NewGuid(), CheckListItemId = Guid.NewGuid() };
        _mockChecklistRepository.Setup(x => x.GetById(It.IsAny<Guid>())).ReturnsAsync(new Checklist());

        // Act
        await _handler.Handle(command, _cancellationToken);

        // Assert
        _mockChecklistRepository.Verify(x => x.SaveChangesAsync(_cancellationToken), Times.Once);
    }
}