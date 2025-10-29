using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailToStudentb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Students",
                newName: "Passwords");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Passwords",
                table: "Students",
                newName: "Password");
        }
    }
}
