using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelApp_DotnetMVC.Migrations
{
    /// <inheritdoc />
    public partial class ChangedImageDataType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Destination",
                type: "BLOB",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Destination",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "BLOB",
                oldNullable: true);
        }
    }
}
