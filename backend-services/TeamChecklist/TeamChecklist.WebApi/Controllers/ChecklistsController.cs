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
}