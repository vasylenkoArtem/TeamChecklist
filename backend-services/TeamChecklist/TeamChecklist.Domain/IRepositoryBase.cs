namespace TeamChecklist.Domain;

public interface IRepositoryBase
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}