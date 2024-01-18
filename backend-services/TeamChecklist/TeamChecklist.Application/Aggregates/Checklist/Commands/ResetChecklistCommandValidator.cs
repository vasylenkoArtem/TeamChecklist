using FluentValidation;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistCommandValidator : AbstractValidator<ResetChecklistCommand>
{
    public ResetChecklistCommandValidator()
    {
        RuleFor(x => x.ChecklistId)
            .NotEmpty();
    }
}