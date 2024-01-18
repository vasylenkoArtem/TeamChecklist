using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamChecklist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChecklistIdToCheckListItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistsItems_Checklists_ChecklistId",
                table: "ChecklistsItems");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistsItems_Checklists_ChecklistId",
                table: "ChecklistsItems",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
