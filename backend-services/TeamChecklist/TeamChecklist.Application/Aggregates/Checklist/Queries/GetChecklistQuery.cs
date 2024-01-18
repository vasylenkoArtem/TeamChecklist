using MediatR;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Queries;

public class GetChecklistQuery: IRequest<ChecklistDto>
{
    public ChecklistType ChecklistType { get; set; }
}