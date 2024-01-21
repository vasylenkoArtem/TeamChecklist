using FluentValidation.TestHelper;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using Xunit;

namespace TeamChecklist.UnitTests.Application.Aggregates.Checklist;

public class MarkChecklistItemAsDoneCommandValidatorTests
{
    private readonly MarkChecklistItemAsDoneCommandValidator _validator;

    public MarkChecklistItemAsDoneCommandValidatorTests()
    {
        _validator = new MarkChecklistItemAsDoneCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_CheckListId_Is_Empty()
    {
        var command = new MarkChecklistItemAsDoneCommand { CheckListId = Guid.Empty, CheckListItemId = Guid.NewGuid() };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.CheckListId);
    }

    [Fact]
    public void Should_Have_Error_When_CheckListItemId_Is_Empty()
    {
        var command = new MarkChecklistItemAsDoneCommand { CheckListId = Guid.NewGuid(), CheckListItemId = Guid.Empty };
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.CheckListItemId);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Ids_Are_Valid()
    {
        var command = new MarkChecklistItemAsDoneCommand
            { CheckListId = Guid.NewGuid(), CheckListItemId = Guid.NewGuid() };
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveValidationErrorFor(x => x.CheckListId);
        result.ShouldNotHaveValidationErrorFor(x => x.CheckListItemId);
    }
}