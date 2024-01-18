using MediatR;
using TeamChecklist.Application.Aggregates.Checklist.Mapping;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistCommandHandler: IRequestHandler<ResetChecklistCommand, ChecklistDto>
{
    private readonly IChecklistRepository _checklistRepository;

    public ResetChecklistCommandHandler(IChecklistRepository checklistRepository)
    {
        _checklistRepository = checklistRepository;
    }
    
    public async Task<ChecklistDto> Handle(
        ResetChecklistCommand request, CancellationToken cancellationToken)
    {
        var domainChecklist = await _checklistRepository.GetById(request.ChecklistId);
        
        domainChecklist.ResetChecklist();

        return domainChecklist.Map();
    }
}