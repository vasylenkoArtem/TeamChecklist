using Xunit;
using Moq;
using System;
using System.Threading;
using FluentAssertions;
using TeamChecklist.Application.Aggregates.Checklist.Queries;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Domain.UserAggregate;

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
        _mockChecklistRepository.Setup(x => x.GetFirst(ChecklistType.Morning))
            .ReturnsAsync(new Checklist()
            {
                Items = new List<ChecklistItem>()
                {
                    new ChecklistItem()
                    {
                        CompletedByUser = new User()
                        {
                            Id = Guid.NewGuid(),
                            Username = "Test username"
                        }
                    }
                }
            });

        // Act
        var user = await _handler.Handle(query, _cancellationToken);

        // Assert
        _mockChecklistRepository.Verify(x => x.GetFirst(query.ChecklistType), Times.Once);
        
        user.Should().NotBeNull();
        user.Items.Should().NotBeEmpty();
        user.Items.First().CompletedBy.Should().NotBeNull();
    }
}