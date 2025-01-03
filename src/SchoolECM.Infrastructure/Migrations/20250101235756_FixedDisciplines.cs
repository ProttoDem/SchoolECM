using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixedDisciplines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                schema: "schoolEcm",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_TeacherId",
                schema: "schoolEcm",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                schema: "schoolEcm",
                table: "Disciplines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                schema: "schoolEcm",
                table: "Disciplines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_TeacherId",
                schema: "schoolEcm",
                table: "Disciplines",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Teachers_TeacherId",
                schema: "schoolEcm",
                table: "Disciplines",
                column: "TeacherId",
                principalSchema: "schoolEcm",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
