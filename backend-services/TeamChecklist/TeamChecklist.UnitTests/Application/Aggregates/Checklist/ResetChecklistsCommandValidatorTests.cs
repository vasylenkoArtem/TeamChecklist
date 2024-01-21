using Xunit;
using FluentValidation.TestHelper;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Domain.ChecklistAggregate;

public class ResetChecklistsCommandValidatorTests
{
    private readonly ResetChecklistsCommandValidator _validator;

    public ResetChecklistsCommandValidatorTests()
    {
        _validator = new ResetChecklistsCommandValidator();
    }

    [Fact]
    public void ShouldHaveErrorWhenChecklistTypeIsEmpty()
    {
        var model = new ResetChecklistsCommand();
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ChecklistType);
    }

    [Fact]
    public void ShouldHaveErrorWhenChecklistTypeIsUnknown()
    {
        var model = new ResetChecklistsCommand { ChecklistType = ChecklistType.Unknown };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ChecklistType);
    }

    [Fact]
    public void ShouldNotHaveErrorWhenChecklistTypeIsValid()
    {
        var model = new ResetChecklistsCommand { ChecklistType = ChecklistType.Morning };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.ChecklistType);
    }
}