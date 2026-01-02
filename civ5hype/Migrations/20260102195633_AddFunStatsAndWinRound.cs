using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace civ5hype.Migrations
{
    /// <inheritdoc />
    public partial class AddFunStatsAndWinRound : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WinRound",
                table: "Games",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinRound",
                table: "Games");
        }
    }
}
