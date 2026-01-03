using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace civ5hype.Migrations
{
    /// <inheritdoc />
    public partial class AddAllNewFeatures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HalberSiegOpStart",
                table: "GamePlayers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SiegerDerHerzen",
                table: "GamePlayers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Betrueger",
                table: "GamePlayers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SkillLevel",
                table: "GamePlayers",
                type: "integer",
                nullable: true);

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
                name: "HalberSiegOpStart",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "SiegerDerHerzen",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "Betrueger",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "SkillLevel",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "WinRound",
                table: "Games");
        }
    }
}
