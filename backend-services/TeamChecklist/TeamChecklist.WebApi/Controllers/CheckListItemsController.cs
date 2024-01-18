using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Application.DTOs;

namespace TeamChecklist.Controllers;

[Route("checklists")]
public class CheckListItemsController: ControllerBase
{
    private readonly IMediator _mediator;

    public CheckListItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id}/mark-as-done")]
    public async Task<ActionResult<ChecklistDto>> MarkItemAsDone(Guid id)
    {
        var command = new MarkChecklistItemAsDoneCommand()
        {
            CheckListItemId = id
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}