using MediatR;
using TeamChecklist.Application.DTOs;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class MarkChecklistItemAsDoneCommand: IRequest<ChecklistItemDto>
{
    public Guid CheckListItemId { get; set; }
}