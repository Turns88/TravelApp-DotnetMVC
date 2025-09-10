using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp_DotnetMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Comment",
                newName: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Comment",
                newName: "UserId");
        }
    }
}
