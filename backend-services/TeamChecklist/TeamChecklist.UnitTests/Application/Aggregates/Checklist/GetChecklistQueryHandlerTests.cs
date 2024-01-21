using Xunit;
using Moq;
using System;
using System.Threading;
using TeamChecklist.Application.Aggregates.Checklist.Queries;
using TeamChecklist.Domain.ChecklistAggregate;

public class GetChecklistQueryHandlerTests
{
    private readonly Mock<IChecklistRepository> _mockChecklistRepository;
    private readonly GetChecklistQueryHandler _handler;
    private readonly CancellationToken _cancellationToken;

    public GetChecklistQueryHandlerTests()
    {
        _mockChecklistRepository = new Mock<IChecklistRepository>();
        _handler = new GetChecklistQueryHandler(_mockChecklistRepository.Object);
        _cancellationToken = new CancellationToken();
    }

    [Fact]
    public async Task Handle_ShouldCallGetByTypeOnce()
    {
        // Arrange
        var query = new GetChecklistQuery { ChecklistType = ChecklistType.Morning };
        _mockChecklistRepository.Setup(x => x.GetFirst(ChecklistType.Morning)).ReturnsAsync(new Checklist());

        // Act
        await _handler.Handle(query, _cancellationToken);

        // Assert
        _mockChecklistRepository.Verify(x => x.GetFirst(query.ChecklistType), Times.Once);
    }
}