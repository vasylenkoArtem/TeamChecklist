using MediatR;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistCommand: IRequest<ChecklistDto>
{
    public Guid ChecklistId { get; set; }
}