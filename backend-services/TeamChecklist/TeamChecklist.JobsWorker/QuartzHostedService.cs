using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;
using TeamChecklist.JobsWorker.Jobs;

namespace TeamChecklist.JobsWorker;

public class QuartzHostedService : IHostedService
{
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly IConfiguration _configuration;
    private IScheduler _scheduler;
    private readonly IJobFactory _jobFactory;

    public QuartzHostedService(
        ISchedulerFactory schedulerFactory,IJobFactory? jobFactory, IConfiguration configuration)
    {
        _schedulerFactory = schedulerFactory;
        _configuration = configuration;
        _jobFactory = jobFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
        _scheduler.JobFactory = _jobFactory;

        var jobDetail = JobBuilder.Create<ResetMorningChecklistsJob>()
            .WithIdentity("ResetMorningChecklistsJob", "group1")
            .Build();

        var jobScheduleConfig = _configuration.GetSection("ResetMorningChecklistsJobSchedule");
        int hour = jobScheduleConfig.GetValue<int>("HourOfTheDay");
        int minute = jobScheduleConfig.GetValue<int>("MinuteOfTheDay");

        var trigger = TriggerBuilder.Create()
            .WithIdentity("ResetMorningChecklistsTrigger", "group1")
            .StartNow()
            .WithDailyTimeIntervalSchedule(s => 
                s.StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute))
                    .InTimeZone(TimeZoneInfo.Local))
            .Build();

        await _scheduler.ScheduleJob(jobDetail, trigger, cancellationToken);
        await _scheduler.Start(cancellationToken);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _scheduler.Shutdown(cancellationToken);
    }
}