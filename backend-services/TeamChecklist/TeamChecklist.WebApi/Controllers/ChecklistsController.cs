using MediatR;
using Microsoft.AspNetCore.Mvc;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Application.Aggregates.Checklist.Queries;
using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Controllers;

[Route("checklists")]
public class ChecklistsController: ControllerBase
{
    private const string UserId = "7a77b40c-30ec-4d3b-b804-afdc34263f9b";
    
    private readonly IMediator _mediator;

    public ChecklistsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{typeId}")]
    public async Task<ActionResult<ChecklistDto>> GetCheckList(ChecklistType typeId)
    {
        var command = new GetChecklistQuery()
        {
            ChecklistType = typeId
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPost("{typeId}/reset")]
    public async Task<ActionResult<ChecklistDto>> ResetChecklist(ChecklistType typeId)
    {
        var command = new ResetChecklistsCommand()
        {
           ChecklistType  = typeId
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
    
    [HttpPost("{checklistId}/item/{itemId}/mark-as-done")]
    public async Task<ActionResult<ChecklistDto>> MarkItemAsDone(Guid checklistId, Guid itemId)
    {
        var command = new MarkChecklistItemAsDoneCommand()
        {
            CheckListItemId = itemId,
            CheckListId = checklistId,
            UserId = Guid.Parse(UserId)
        };

        var result = await _mediator.Send(command);

        return Ok(result);
    }
}