﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;
using System;
using System.IO;
using System.Threading.Tasks;
using TeamChecklist.Application;
using TeamChecklist.Infrastructure;

namespace TeamChecklist.JobsWorker;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                var configuration = hostContext.Configuration;
                services.AddSingleton<IConfiguration>(configuration);

                var sqlConnectionString = configuration.GetConnectionString("ConnectionStrings:DefaultConnection");

                services.AddSqlServerDatabase(sqlConnectionString);

                services.AddApplication();
                
                services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
                services.AddHostedService<QuartzHostedService>();
            });
}