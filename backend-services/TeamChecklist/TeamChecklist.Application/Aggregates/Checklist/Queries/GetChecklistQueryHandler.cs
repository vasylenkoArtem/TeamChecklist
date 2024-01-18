using MediatR;
using TeamChecklist.Application.Aggregates.Checklist.Mapping;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Queries;

public class GetChecklistQueryHandler : IRequestHandler<GetChecklistQuery, ChecklistDto>
{
    private readonly IChecklistRepository _checklistRepository;

    public GetChecklistQueryHandler(IChecklistRepository checklistRepository)
    {
        _checklistRepository = checklistRepository;
    }

    public async Task<ChecklistDto> Handle(
        GetChecklistQuery request, CancellationToken cancellationToken)
    {
        var domainChecklist = await _checklistRepository.GetFirst(request.ChecklistType);

        var dtoModel = domainChecklist.Map();

        return dtoModel;
    }
}