using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
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
    
    
}