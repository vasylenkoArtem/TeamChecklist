using MediatR;
using Quartz;
using TeamChecklist.Application.Aggregates.Checklist.Commands;
using TeamChecklist.Domain.ChecklistAggregate;


namespace TeamChecklist.JobsWorker.Jobs;

public class ResetMorningChecklistsJob: IJob
{
    private readonly IMediator _mediator;

    public ResetMorningChecklistsJob(IMediator mediator)
    {
        _mediator = mediator;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        await _mediator.Send(new ResetChecklistsCommand()
        {
            ChecklistType = ChecklistType.Morning
        });

        await Task.CompletedTask;
    }
}