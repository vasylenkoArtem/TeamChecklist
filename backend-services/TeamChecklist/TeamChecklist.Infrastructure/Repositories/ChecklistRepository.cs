using Microsoft.EntityFrameworkCore;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Domain.Exceptions;

namespace TeamChecklist.Infrastructure.Repositories;

public class ChecklistRepository : IChecklistRepository
{
    private readonly TeamChecklistDbContext _dbContext;

    public ChecklistRepository(TeamChecklistDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Checklist> GetFirst(ChecklistType type)
    {
        var checklist = await _dbContext.Checklists.FirstOrDefaultAsync(x => x.Type == type);

        if (checklist is null)
        {
            throw new DomainException($"Checklist with type {type.ToString()} is not found");
        }

        return checklist;
    }

    public async Task<Checklist> GetById(Guid id)
    {
        var checklist = await _dbContext.Checklists.FindAsync(id);

        if (checklist is null)
        {
            throw new DomainException($"Checklist with id {id} is not found");
        }

        return checklist;
    }
}