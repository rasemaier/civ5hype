using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace civ5hype.Migrations
{
    /// <inheritdoc />
    public partial class AddFunStatistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Betrueger",
                table: "GamePlayers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Betrueger",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "HalberSiegOpStart",
                table: "GamePlayers");

            migrationBuilder.DropColumn(
                name: "SiegerDerHerzen",
                table: "GamePlayers");
        }
    }
}
