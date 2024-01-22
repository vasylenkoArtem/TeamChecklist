using TeamChecklist.Domain.Exceptions;

namespace TeamChecklist.Domain.ChecklistAggregate;

public class Checklist
{
    public Checklist()
    {
        Items = new List<ChecklistItem>();
    }

    public Guid Id { get; set; }

    public DateTime? CompletedDate { get; set; }

    public CheckListStatus Status { get; set; }

    public ChecklistType Type { get; set; }

    public IList<ChecklistItem> Items { get; set; }

    public ChecklistItem MarkItemAsDone(Guid itemId, Guid userId)
    {
        var item = Items.FirstOrDefault(x => x.Id == itemId);

        if (item is null)
        {
            throw new DomainException($"ChecklistItem with id {itemId} is not found");
        }

        item.ChangeStatus(ChecklistItemStatus.Done, userId);

        if (Items.All(x => x.Status == ChecklistItemStatus.Done))
        {
            Status = CheckListStatus.Done;
            CompletedDate = DateTime.Now;
        }
        else if (Items.Any(x => x.Status == ChecklistItemStatus.Done))
        {
            Status = CheckListStatus.InProgress;
        }

        return item;
    }

    public void ResetChecklist()
    {
        Status = CheckListStatus.ToDo;
        CompletedDate = null;
        
        foreach (var item in Items)
        {
            item.ChangeStatus(ChecklistItemStatus.ToDo, Guid.Empty);
        }
    }
}