﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeamChecklist.Infrastructure;

#nullable disable

namespace TeamChecklist.Infrastructure.Migrations
{
    [DbContext(typeof(TeamChecklistDbContext))]
    partial class TeamChecklistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeamChecklist.Domain.ChecklistAggregate.Checklist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Checklists");

                    b.HasData(
                        new
                        {
                            Id = new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                            Status = 0,
                            Type = 1
                        });
                });

            modelBuilder.Entity("TeamChecklist.Domain.ChecklistAggregate.ChecklistItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("ChecklistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CompletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TextDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistId");

                    b.HasIndex("CompletedBy");

                    b.ToTable("ChecklistsItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("279d04dd-53ac-432d-a906-5e6a2de8c3ff"),
                            ChecklistId = new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                            Status = 0,
                            TextDescription = "Turn on kitchen ventilation"
                        },
                        new
                        {
                            Id = new Guid("2ad1560f-5f23-40ac-ae70-b6b4c6cbcd1d"),
                            ChecklistId = new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                            Status = 0,
                            TextDescription = "Turn on the coffee machine power supply"
                        },
                        new
                        {
                            Id = new Guid("b31615ce-3a2e-4c50-8a77-d993437a74e5"),
                            ChecklistId = new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                            Status = 0,
                            TextDescription = "Start unfreezing semi-finished products from freezer"
                        },
                        new
                        {
                            Id = new Guid("9132432e-b53c-4a1f-bb8c-8124194ab9e0"),
                            ChecklistId = new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                            Status = 0,
                            TextDescription = "Prepare cups"
                        },
                        new
                        {
                            Id = new Guid("2c872939-d57e-4c11-bdd7-5312378184b8"),
                            ChecklistId = new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"),
                            Status = 0,
                            TextDescription = "Turn on kitchen ventilation"
                        });
                });

            modelBuilder.Entity("TeamChecklist.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7a77b40c-30ec-4d3b-b804-afdc34263f9b"),
                            Username = "TestUserName"
                        });
                });

            modelBuilder.Entity("TeamChecklist.Domain.ChecklistAggregate.ChecklistItem", b =>
                {
                    b.HasOne("TeamChecklist.Domain.ChecklistAggregate.Checklist", "Checklist")
                        .WithMany("Items")
                        .HasForeignKey("ChecklistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeamChecklist.Domain.UserAggregate.User", "CompletedByUser")
                        .WithMany()
                        .HasForeignKey("CompletedBy")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Checklist");

                    b.Navigation("CompletedByUser");
                });

            modelBuilder.Entity("TeamChecklist.Domain.ChecklistAggregate.Checklist", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
