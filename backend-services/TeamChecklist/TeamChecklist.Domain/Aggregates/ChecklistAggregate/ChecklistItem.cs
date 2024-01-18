namespace TeamChecklist.Domain.ChecklistAggregate;

public class ChecklistItem
{
    public Guid Id { get; set; }

    public string TextDescription { get; set; }

    public ChecklistItemStatus Status { get; set; }

    public Guid? CompletedBy { get; set; }
    
    public DateTime? CompletedDate { get; set; }

    public Guid ChecklistId { get; set; }
    
    public Checklist Checklist { get; set; }

    public void ChangeStatus(ChecklistItemStatus newStatus)
    {
        CompletedDate = newStatus switch
        {
            ChecklistItemStatus.Done => DateTime.Now,
            ChecklistItemStatus.ToDo => null,
            _ => CompletedDate
        };

        Status = newStatus;
    }
}