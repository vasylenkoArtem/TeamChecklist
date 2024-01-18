using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Infrastructure;

public class TeamChecklistDbContext : DbContext
{
    public TeamChecklistDbContext()
    {
    }
    
    public TeamChecklistDbContext([NotNull] DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Checklist> Checklists { get; set; }
    
    public DbSet<ChecklistItem> ChecklistsItems { get; set; }
    
    // Configuration for EF migrations run
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfiguration Configuration = builder.Build();

        optionsBuilder.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection"));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}