using TeamChecklist.Domain;

namespace TeamChecklist.Infrastructure.Repositories;

public abstract class RepositoryBase : IRepositoryBase
{
    protected readonly TeamChecklistDbContext _dbContext;

    protected RepositoryBase(TeamChecklistDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}