﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChecklist.Domain.ChecklistAggregate;

namespace TeamChecklist.Infrastructure.Configurations.Aggregates.ChecklistAggregate;

public class ChecklistItemConfiguration
    : IEntityTypeConfiguration<ChecklistItem>
{
    public void Configure(EntityTypeBuilder<ChecklistItem> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("newsequentialid()");
        builder.Property(x => x.Status)
            .IsRequired(true);
        builder.Property(x => x.TextDescription)
            .IsRequired(true);
        builder.HasOne(x => x.CompletedByUser)
            .WithMany()
            .HasForeignKey(x => x.CompletedBy)
            .OnDelete(DeleteBehavior.NoAction);
    }
}