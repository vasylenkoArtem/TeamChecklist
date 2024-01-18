namespace TeamChecklist.Domain.ChecklistAggregate;

public interface IChecklistRepository
{
    Task<Checklist> GetFirst(ChecklistType type);
    
    Task<Checklist> GetById(Guid id);
}