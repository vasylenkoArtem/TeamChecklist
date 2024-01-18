using MediatR;
using TeamChecklist.Application.Aggregates.Checklist.Mapping;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistsCommandHandler: IRequestHandler<ResetChecklistsCommand, Unit>
{
    private readonly IChecklistRepository _checklistRepository;

    public ResetChecklistsCommandHandler(IChecklistRepository checklistRepository)
    {
        _checklistRepository = checklistRepository;
    }
    
    public async Task<Unit> Handle(
        ResetChecklistsCommand request, CancellationToken cancellationToken)
    {
        var domainChecklist = await _checklistRepository.GetAll(request.ChecklistType);

        foreach (var checklist in domainChecklist)
        {
            checklist.ResetChecklist();
        }

        await _checklistRepository.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}