using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    /// <inheritdoc />
    public partial class Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance");

            migrationBuilder.RenameTable(
                name: "Attendance",
                newName: "Attendances");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Attendances",
                newName: "Section");

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPresent",
                table: "Attendances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendances",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Class",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsPresent",
                table: "Attendances");

            migrationBuilder.RenameTable(
                name: "Attendances",
                newName: "Attendance");

            migrationBuilder.RenameColumn(
                name: "Section",
                table: "Attendance",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendance",
                table: "Attendance",
                column: "Id");
        }
    }
}
