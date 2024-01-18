using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Infrastructure.Repositories;

namespace TeamChecklist.Infrastructure;

public static class DependenciesBootstrapper
{
    public static IServiceCollection AddSqlServerDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TeamChecklistDbContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(typeof(TeamChecklistDbContext).Assembly.FullName));

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IChecklistRepository, ChecklistRepository>();
        
        return services;
    }
}