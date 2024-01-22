using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamChecklist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateChecklistItemUserColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistsItems_CompletedBy",
                table: "ChecklistsItems",
                column: "CompletedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistsItems_Users_CompletedBy",
                table: "ChecklistsItems",
                column: "CompletedBy",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistsItems_Users_CompletedBy",
                table: "ChecklistsItems");

            migrationBuilder.DropIndex(
                name: "IX_ChecklistsItems_CompletedBy",
                table: "ChecklistsItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }
    }
}
