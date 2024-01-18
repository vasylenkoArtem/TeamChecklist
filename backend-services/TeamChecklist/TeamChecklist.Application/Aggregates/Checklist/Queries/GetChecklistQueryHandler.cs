using MediatR;
using TeamChecklist.Application.DTOs;

namespace TeamChecklist.Application.Aggregates.Checklist.Queries;

public class GetChecklistQueryHandler : IRequestHandler<GetChecklistQuery, ChecklistDto>
{
    public async Task<ChecklistDto> Handle(
        GetChecklistQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}