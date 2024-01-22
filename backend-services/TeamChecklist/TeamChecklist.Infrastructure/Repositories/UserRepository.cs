using Microsoft.EntityFrameworkCore;
using TeamChecklist.Domain.Exceptions;
using TeamChecklist.Domain.UserAggregate;

namespace TeamChecklist.Infrastructure.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public UserRepository(TeamChecklistDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<User> GetById(Guid id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        
        if (user is null)
        {
            throw new DomainException($"User with id {id} is not found");
        }
        
        return user;
    }
}