using TeamChecklist.Application.DTOs;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Application.Aggregates.Checklist.Mapping;

public static class ChecklistMappingExtensions
{
    public static ChecklistDto Map(this Domain.ChecklistAggregate.Checklist domainChecklist)
    {
        var dtoModel = new ChecklistDto()
        {
            Id = domainChecklist.Id,
            Status = domainChecklist.Status,
            CompletedDate = domainChecklist.CompletedDate,
            Items = domainChecklist.Items.Select(Map).ToList()
        };
        return dtoModel;
    }

    public static ChecklistItemDto Map(this ChecklistItem item)
    {
        return new ChecklistItemDto()
        {
            Id = item.Id,
            Status = item.Status,
            CompletedBy = item.CompletedBy,
            TextDescription = item.TextDescription
        };
    }
}