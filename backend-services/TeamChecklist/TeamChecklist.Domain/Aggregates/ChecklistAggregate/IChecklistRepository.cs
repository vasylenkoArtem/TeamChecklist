namespace TeamChecklist.Domain.ChecklistAggregate;

public interface IChecklistRepository
{
    Task<Checklist> GetFirst(ChecklistType type);

    Task<List<Checklist>> GetAll(ChecklistType type);
    
    Task<Checklist> GetById(Guid id);

    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}