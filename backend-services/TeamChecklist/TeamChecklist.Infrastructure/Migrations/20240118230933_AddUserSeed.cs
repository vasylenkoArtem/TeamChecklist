using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamChecklist.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Username" },
                values: new object[] { new Guid("7a77b40c-30ec-4d3b-b804-afdc34263f9b"), "TestUserName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("7a77b40c-30ec-4d3b-b804-afdc34263f9b"));
        }
    }
}
