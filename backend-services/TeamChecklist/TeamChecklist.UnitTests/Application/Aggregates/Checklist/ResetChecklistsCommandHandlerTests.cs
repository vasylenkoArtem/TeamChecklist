using Xunit;
using Moq;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Domain.ChecklistAggregate;

public class ResetChecklistsCommandHandlerTests
{
    private readonly Mock<IChecklistRepository> _mockChecklistRepository;
    private readonly ResetChecklistsCommandHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public ResetChecklistsCommandHandlerTests()
    {
        _mockChecklistRepository = new Mock<IChecklistRepository>();
        _handler = new ResetChecklistsCommandHandler(_mockChecklistRepository.Object);
        _cancellationToken = new CancellationToken();
    }

    [Fact]
    public async Task Handle_ShouldCallGetAllOnce()
    {
        // Arrange
        var command = new ResetChecklistsCommand { ChecklistType = ChecklistType.Morning };
        _mockChecklistRepository.Setup(x => x.GetAll(ChecklistType.Morning))
            .ReturnsAsync(new List<Checklist>());

        // Act
        await _handler.Handle(command, _cancellationToken);

        // Assert
        _mockChecklistRepository.Verify(x => x.GetAll(command.ChecklistType), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCallResetChecklistForEachItem()
    {
        // Arrange
        var command = new ResetChecklistsCommand { ChecklistType = ChecklistType.Morning };
        var checklists = new List<Checklist> { new Checklist(), new Checklist() };
        _mockChecklistRepository.Setup(x => x.GetAll(ChecklistType.Morning))
            .ReturnsAsync(checklists);

        // Act
        await _handler.Handle(command, _cancellationToken);

        // Assert
        Assert.All(checklists, checklist => Assert.Equal(CheckListStatus.ToDo, checklist.Status));
    }

    [Fact]
    public async Task Handle_ShouldCallSaveChangesOnce()
    {
        // Arrange
        var command = new ResetChecklistsCommand { ChecklistType = ChecklistType.Morning };
        _mockChecklistRepository.Setup(x => x.GetAll(ChecklistType.Morning))
            .ReturnsAsync(new List<Checklist>());

        // Act
        await _handler.Handle(command, _cancellationToken);

        // Assert
        _mockChecklistRepository.Verify(x => x.SaveChangesAsync(_cancellationToken), Times.Once);
    }
}