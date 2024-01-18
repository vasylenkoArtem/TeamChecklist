using MediatR;
using TeamChecklist.Application.DTOs;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class MarkChecklistItemAsDoneCommandHandler: IRequestHandler<MarkChecklistItemAsDoneCommand, ChecklistItemDto>
{
    public async Task<ChecklistItemDto> Handle(
        MarkChecklistItemAsDoneCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}