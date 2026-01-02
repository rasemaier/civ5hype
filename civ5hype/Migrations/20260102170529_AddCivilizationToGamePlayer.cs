using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace civ5hype.Migrations
{
    /// <inheritdoc />
    public partial class AddCivilizationToGamePlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Civilization",
                table: "GamePlayers",
                type: "TEXT",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Civilization",
                table: "GamePlayers");
        }
    }
}
