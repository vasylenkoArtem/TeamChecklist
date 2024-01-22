
namespace TeamChecklist.Domain.ChecklistAggregate;

public interface IChecklistRepository : IRepositoryBase
{
    Task<Checklist> GetFirst(ChecklistType type);

    Task<List<Checklist>> GetAll(ChecklistType type);
    
    Task<Checklist> GetById(Guid id);
}