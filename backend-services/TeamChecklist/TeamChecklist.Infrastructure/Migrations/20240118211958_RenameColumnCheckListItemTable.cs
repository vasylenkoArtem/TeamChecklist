using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamChecklist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnCheckListItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistsItems_Checklists_ChcklistId",
                table: "ChecklistsItems");

            migrationBuilder.RenameColumn(
                name: "ChcklistId",
                table: "ChecklistsItems",
                newName: "ChecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistsItems_ChcklistId",
                table: "ChecklistsItems",
                newName: "IX_ChecklistsItems_ChecklistId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistsItems_Checklists_ChecklistId",
                table: "ChecklistsItems",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistsItems_Checklists_ChecklistId",
                table: "ChecklistsItems");

            migrationBuilder.DeleteData(
                table: "ChecklistsItems",
                keyColumn: "Id",
                keyValue: new Guid("279d04dd-53ac-432d-a906-5e6a2de8c3ff"));

            migrationBuilder.DeleteData(
                table: "ChecklistsItems",
                keyColumn: "Id",
                keyValue: new Guid("2ad1560f-5f23-40ac-ae70-b6b4c6cbcd1d"));

            migrationBuilder.DeleteData(
                table: "ChecklistsItems",
                keyColumn: "Id",
                keyValue: new Guid("2c872939-d57e-4c11-bdd7-5312378184b8"));

            migrationBuilder.DeleteData(
                table: "ChecklistsItems",
                keyColumn: "Id",
                keyValue: new Guid("9132432e-b53c-4a1f-bb8c-8124194ab9e0"));

            migrationBuilder.DeleteData(
                table: "ChecklistsItems",
                keyColumn: "Id",
                keyValue: new Guid("b31615ce-3a2e-4c50-8a77-d993437a74e5"));

            migrationBuilder.DeleteData(
                table: "Checklists",
                keyColumn: "Id",
                keyValue: new Guid("be5220e3-b0bb-4bd8-8bd5-9a70d35182a7"));

            migrationBuilder.RenameColumn(
                name: "ChecklistId",
                table: "ChecklistsItems",
                newName: "ChcklistId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistsItems_ChecklistId",
                table: "ChecklistsItems",
                newName: "IX_ChecklistsItems_ChcklistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistsItems_Checklists_ChcklistId",
                table: "ChecklistsItems",
                column: "ChcklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
