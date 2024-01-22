using MediatR;
using TeamChecklist.Application.Aggregates.Checklist.Mapping;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class MarkChecklistItemAsDoneCommandHandler: IRequestHandler<MarkChecklistItemAsDoneCommand, ChecklistItemDto>
{
    private readonly IChecklistRepository _checklistRepository;

    public MarkChecklistItemAsDoneCommandHandler(IChecklistRepository checklistRepository)
    {
        _checklistRepository = checklistRepository;
    }

    public async Task<ChecklistItemDto> Handle(
        MarkChecklistItemAsDoneCommand request, CancellationToken cancellationToken)
    {
        var checklist = await _checklistRepository.GetById(request.CheckListId);

        var checklistItem = checklist.MarkItemAsDone(request.CheckListItemId, request.UserId);

        await _checklistRepository.SaveChangesAsync(cancellationToken);
        
        return checklistItem.Map();
    }
}