using TeamChecklist.Domain.UserAggregate;

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

    public User CompletedByUser { get; set; }

    public void ChangeStatus(ChecklistItemStatus newStatus, Guid userId)
    {
        switch (newStatus)
        {
            case ChecklistItemStatus.Done:
                CompletedDate = DateTime.Now;
                CompletedBy = userId;
                break;
            case ChecklistItemStatus.ToDo:
                CompletedDate = null;
                CompletedBy = null;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newStatus), newStatus, null);
        }

        Status = newStatus;
    }
}