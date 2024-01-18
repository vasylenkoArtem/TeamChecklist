using FluentValidation;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Queries;

public class GetChecklistQueryValidator : AbstractValidator<GetChecklistQuery>
{
    public GetChecklistQueryValidator()
    {
        RuleFor(x => x.ChecklistType)
            .NotEmpty();
        RuleFor(x => x.ChecklistType)
            .NotEqual(ChecklistType.Unknown);
    }
}