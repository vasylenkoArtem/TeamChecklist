namespace TeamChecklist.Domain.ChecklistAggregate;

public class Checklist
{
    public Guid Id { get; set; }
    
    public DateTime CompletedDate { get; set; }

    public CheckListStatus Status { get; set; }

    public ChecklistType Type { get; set; }
    
    public IList<ChecklistItem> Items { get; set; }
}