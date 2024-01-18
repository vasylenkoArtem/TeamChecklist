using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamChecklist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Checklists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Username = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistsItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    TextDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CompletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChecklistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistsItems_Checklists_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Checklists",
                columns: new[] { "Id", "CompletedDate", "Status", "Type" },
                values: new object[] { new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"), null, 0, 1 });

            migrationBuilder.InsertData(
                table: "ChecklistsItems",
                columns: new[] { "Id", "ChecklistId", "CompletedBy", "CompletedDate", "Status", "TextDescription" },
                values: new object[,]
                {
                    { new Guid("279d04dd-53ac-432d-a906-5e6a2de8c3ff"), new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"), null, null, 0, "Turn on kitchen ventilation" },
                    { new Guid("2ad1560f-5f23-40ac-ae70-b6b4c6cbcd1d"), new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"), null, null, 0, "Turn on the coffee machine power supply" },
                    { new Guid("2c872939-d57e-4c11-bdd7-5312378184b8"), new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"), null, null, 0, "Turn on kitchen ventilation" },
                    { new Guid("9132432e-b53c-4a1f-bb8c-8124194ab9e0"), new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"), null, null, 0, "Prepare cups" },
                    { new Guid("b31615ce-3a2e-4c50-8a77-d993437a74e5"), new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"), null, null, 0, "Start unfreezing semi-finished products from freezer" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistsItems_ChecklistId",
                table: "ChecklistsItems",
                column: "ChecklistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistsItems");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Checklists");
        }
    }
}
