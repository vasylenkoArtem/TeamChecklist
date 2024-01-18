using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.DTOs;

public class ChecklistItemDto
{
    public Guid Id { get; set; }

    public string TextDescription { get; set; }

    public ChecklistItemStatus Status { get; set; }

    public Guid? CompletedBy { get; set; }
}