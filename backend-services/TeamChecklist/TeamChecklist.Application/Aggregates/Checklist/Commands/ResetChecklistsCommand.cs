using MediatR;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistsCommand: IRequest<Unit>
{
    public ChecklistType ChecklistType { get; set; }
}