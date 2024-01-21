using FluentValidation.TestHelper;
using TeamChecklist.Application.Aggregates.Checklist.Queries;
using TeamChecklist.Domain.ChecklistAggregate;
using Xunit;

namespace TeamChecklist.UnitTests.Application.Aggregates.Checklist;

public class GetChecklistQueryValidatorTests
{
    private readonly GetChecklistQueryValidator _validator;

    public GetChecklistQueryValidatorTests()
    {
        _validator = new GetChecklistQueryValidator();
    }

    [Fact]
    public void Should_Have_Error_When_ChecklistType_Is_Empty()
    {
        var model = new GetChecklistQuery();
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ChecklistType);
    }

    [Fact]
    public void Should_Have_Error_When_ChecklistType_Is_Unknown()
    {
        var model = new GetChecklistQuery { ChecklistType = ChecklistType.Unknown };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.ChecklistType);
    }

    [Fact]
    public void Should_Not_Have_Error_When_ChecklistType_Is_Valid()
    {
        var model = new GetChecklistQuery { ChecklistType = ChecklistType.Morning };
        var result = _validator.TestValidate(model);
        result.ShouldNotHaveValidationErrorFor(x => x.ChecklistType);
    }
}