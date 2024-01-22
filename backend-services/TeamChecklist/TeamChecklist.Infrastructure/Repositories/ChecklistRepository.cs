using Microsoft.EntityFrameworkCore;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Domain.Exceptions;

namespace TeamChecklist.Infrastructure.Repositories;

public class ChecklistRepository : RepositoryBase, IChecklistRepository
{
    private readonly TeamChecklistDbContext _dbContext;

    public ChecklistRepository(TeamChecklistDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Checklist> GetFirst(ChecklistType type)
    {
        var checklist = await _dbContext.Checklists
            .Include(x => x.Items)
            .ThenInclude(x => x.CompletedByUser)
            .FirstOrDefaultAsync(x => x.Type == type);

        if (checklist is null)
        {
            throw new DomainException($"Checklist with type {type.ToString()} is not found");
        }

        return checklist;
    }

    public async Task<List<Checklist>> GetAll(ChecklistType type)
    {
        var checklistCollection = await _dbContext.Checklists.Include(x => x.Items)
            .Where(x => x.Type == type)
            .ToListAsync();

        return checklistCollection;
    }

    public async Task<Checklist> GetById(Guid id)
    {
        var checklist = await _dbContext.Checklists.Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (checklist is null)
        {
            throw new DomainException($"Checklist with id {id} is not found");
        }

        return checklist;
    }
}