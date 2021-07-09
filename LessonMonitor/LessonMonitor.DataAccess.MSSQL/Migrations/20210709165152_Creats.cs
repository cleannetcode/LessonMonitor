using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class Creats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Homeworks_HomeworkId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_HomeworkId",
                table: "Lessons");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Homeworks_LessonId",
                table: "Homeworks");

            migrationBuilder.DropColumn(
                name: "HomeworkId",
                table: "Lessons");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_MemberId",
                table: "Questions",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Lessons_LessonId",
                table: "Homeworks",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Lessons_LessonId",
                table: "Homeworks");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Homeworks_LessonId",
                table: "Homeworks");

            migrationBuilder.AddColumn<int>(
                name: "HomeworkId",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_HomeworkId",
                table: "Lessons",
                column: "HomeworkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Homeworks_HomeworkId",
                table: "Lessons",
                column: "HomeworkId",
                principalTable: "Homeworks",
                principalColumn: "LessonId");
        }
    }
}
