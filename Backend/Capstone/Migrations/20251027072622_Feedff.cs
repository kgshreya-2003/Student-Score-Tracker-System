using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    /// <inheritdoc />
    public partial class Feedff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassNumber",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Feedbacks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassNumber",
                table: "Feedbacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Feedbacks",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }
    }
}
