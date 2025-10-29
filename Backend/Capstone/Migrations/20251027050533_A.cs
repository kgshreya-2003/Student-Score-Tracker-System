using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capstone.Migrations
{
    /// <inheritdoc />
    public partial class A : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Class",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Section",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Attendances");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Attendances",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_StudentId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "Class",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Section",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Attendances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
