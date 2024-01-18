using MediatR;
using TeamChecklist.Application.DTOs;

namespace TeamChecklist.Application.Aggregates.Checklist.Commands;

public class ResetChecklistCommandHandler: IRequestHandler<ResetChecklistCommand, ChecklistDto>
{
    public async Task<ChecklistDto> Handle(
        ResetChecklistCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}