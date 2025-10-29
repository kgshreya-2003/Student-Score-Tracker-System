using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    /// <inheritdoc />
    public partial class AddGradeTabl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AssignTeachers_AssignTeacherId",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "GradeLetter",
                table: "Grades",
                newName: "GradeValue");

            migrationBuilder.RenameColumn(
                name: "AssignTeacherId",
                table: "Grades",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AssignTeacherId",
                table: "Grades",
                newName: "IX_Grades_TeacherId");

            migrationBuilder.AlterColumn<int>(
                name: "Marks",
                table: "Grades",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_TeacherId",
                table: "Grades",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_TeacherId",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Grades",
                newName: "AssignTeacherId");

            migrationBuilder.RenameColumn(
                name: "GradeValue",
                table: "Grades",
                newName: "GradeLetter");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                newName: "IX_Grades_AssignTeacherId");

            migrationBuilder.AlterColumn<double>(
                name: "Marks",
                table: "Grades",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AssignTeachers_AssignTeacherId",
                table: "Grades",
                column: "AssignTeacherId",
                principalTable: "AssignTeachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
