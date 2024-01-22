using MediatR;
using TeamChecklist.Application.DTOs;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class MarkChecklistItemAsDoneCommand: IRequest<ChecklistItemDto>
{
    public Guid CheckListId { get; set; }
    
    public Guid CheckListItemId { get; set; }
    public Guid UserId { get; set; }
}