using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.DTOs;

public class ChecklistDto
{
    public Guid Id { get; set; }
    
    public DateTime? CompletedDate { get; set; }

    public CheckListStatus Status { get; set; }
    
    public IList<ChecklistItemDto> Items { get; set; }
}