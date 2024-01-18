namespace TeamChecklist.Domain.ChecklistAggregate;

public class ChecklistItem
{
    public Guid Id { get; set; }

    public string TextDescription { get; set; }

    public ChecklistItemStatus Status { get; set; }

    public Guid? CompletedBy { get; set; }
    
    public DateTime? CompletedDate { get; set; }
    
    public Checklist Checklist { get; set; }
}