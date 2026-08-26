using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDVTT.Migrations
{
    /// <inheritdoc />
    public partial class AddAlignmentToCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Alignment",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Initiative",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Proficiency",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Walking",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alignment",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Initiative",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Proficiency",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "Walking",
                table: "Characters");
        }
    }
}
