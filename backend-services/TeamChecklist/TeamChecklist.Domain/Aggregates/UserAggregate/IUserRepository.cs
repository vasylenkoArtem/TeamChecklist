namespace TeamChecklist.Domain.UserAggregate;

public interface IUserRepository : IRepositoryBase
{
    Task<User> GetById(Guid id);
}