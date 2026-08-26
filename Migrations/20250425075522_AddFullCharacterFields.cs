using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDVTT.Migrations
{
    /// <inheritdoc />
    public partial class AddFullCharacterFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Conditions",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrentHP",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Inventory",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MaxHP",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Spellbook",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conditions",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "CurrentHP",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Inventory",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "MaxHP",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Spellbook",
                table: "Characters");
        }
    }
}
