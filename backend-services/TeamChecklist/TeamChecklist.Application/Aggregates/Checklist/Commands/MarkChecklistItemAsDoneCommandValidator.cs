using FluentValidation;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class MarkChecklistItemAsDoneCommandValidator : AbstractValidator<MarkChecklistItemAsDoneCommand>
{
    public MarkChecklistItemAsDoneCommandValidator()
    {
        RuleFor(x => x.CheckListId)
            .NotEmpty();
        RuleFor(x => x.CheckListItemId)
            .NotEmpty();
    }
}