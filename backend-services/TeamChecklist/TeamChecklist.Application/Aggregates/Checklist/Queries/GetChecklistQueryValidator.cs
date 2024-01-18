using FluentValidation;
using TeamChecklist.Application.Aggregates.Checklist.Commands;

namespace TeamChecklist.Application.Aggregates.Checklist.Queries;

public class GetChecklistQueryValidator : AbstractValidator<GetChecklistQuery>
{
    public GetChecklistQueryValidator()
    {
        RuleFor(x => x.ChecklistType)
            .NotEmpty();
    }
}