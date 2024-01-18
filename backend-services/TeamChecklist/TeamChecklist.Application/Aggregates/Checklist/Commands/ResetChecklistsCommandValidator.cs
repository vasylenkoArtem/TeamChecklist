using FluentValidation;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistsCommandValidator : AbstractValidator<ResetChecklistsCommand>
{
    public ResetChecklistsCommandValidator()
    {
        RuleFor(x => x.ChecklistType)
            .NotEmpty();
        RuleFor(x => x.ChecklistType)
            .NotEqual(ChecklistType.Unknown);
    }
}