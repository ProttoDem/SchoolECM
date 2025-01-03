using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedGrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Disciplines_DisciplineId",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Teachers_TeacherId",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_DisciplineId",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "DisciplineId",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeDate",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "GradeTime",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                schema: "schoolEcm",
                table: "Grades",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_TeacherId",
                schema: "schoolEcm",
                table: "Grades",
                newName: "IX_Grades_ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Schedules_ScheduleId",
                schema: "schoolEcm",
                table: "Grades",
                column: "ScheduleId",
                principalSchema: "schoolEcm",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Schedules_ScheduleId",
                schema: "schoolEcm",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                schema: "schoolEcm",
                table: "Grades",
                newName: "TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_ScheduleId",
                schema: "schoolEcm",
                table: "Grades",
                newName: "IX_Grades_TeacherId");

            migrationBuilder.AddColumn<int>(
                name: "DisciplineId",
                schema: "schoolEcm",
                table: "Grades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "GradeDate",
                schema: "schoolEcm",
                table: "Grades",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<TimeOnly>(
                name: "GradeTime",
                schema: "schoolEcm",
                table: "Grades",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Grades_DisciplineId",
                schema: "schoolEcm",
                table: "Grades",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Disciplines_DisciplineId",
                schema: "schoolEcm",
                table: "Grades",
                column: "DisciplineId",
                principalSchema: "schoolEcm",
                principalTable: "Disciplines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Teachers_TeacherId",
                schema: "schoolEcm",
                table: "Grades",
                column: "TeacherId",
                principalSchema: "schoolEcm",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
