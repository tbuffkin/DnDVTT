using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDVTT.Migrations
{
    /// <inheritdoc />
    public partial class AddArmorClassToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArmorClass",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArmorClass",
                table: "Characters");
        }
    }
}
