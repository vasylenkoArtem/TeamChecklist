﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamChecklist.Domain.ChecklistAggregate;
using TeamChecklist.Infrastructure.SeedData.Aggregates.ChecklistAggregate;

namespace TeamChecklist.Infrastructure.Configurations.Aggregates.ChecklistAggregate;

public class ChecklistConfiguration
    : IEntityTypeConfiguration<Checklist>
{
    public void Configure(EntityTypeBuilder<Checklist> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("newsequentialid()");
        builder.Property(x => x.Status)
            .IsRequired(true);
        builder.Property(x => x.Type)
            .IsRequired(true);
        
        builder.HasMany(x => x.Items)
            .WithOne(x => x.Checklist).HasForeignKey(x => x.ChecklistId);
    }
}