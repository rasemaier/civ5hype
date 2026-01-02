using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace civ5hype.Migrations
{
    /// <inheritdoc />
    public partial class AddScreenshotData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScreenshotData",
                table: "Games",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScreenshotData",
                table: "Games");
        }
    }
}
