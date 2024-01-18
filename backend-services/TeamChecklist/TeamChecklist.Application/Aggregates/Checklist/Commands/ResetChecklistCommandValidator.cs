using FluentValidation;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistCommandValidator : AbstractValidator<ResetChecklistCommand>
{
    public ResetChecklistCommandValidator()
    {
        RuleFor(x => x.ChecklistType)
            .NotEmpty();
    }
}