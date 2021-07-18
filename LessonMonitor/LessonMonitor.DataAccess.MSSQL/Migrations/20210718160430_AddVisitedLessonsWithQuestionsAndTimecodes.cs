using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class AddVisitedLessonsWithQuestionsAndTimecodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitedLessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitedLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitedLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VisitedLessons_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitedLessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_VisitedLessons_VisitedLessonId",
                        column: x => x.VisitedLessonId,
                        principalTable: "VisitedLessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Timecodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitedLessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timecodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timecodes_VisitedLessons_VisitedLessonId",
                        column: x => x.VisitedLessonId,
                        principalTable: "VisitedLessons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_VisitedLessonId",
                table: "Questions",
                column: "VisitedLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Timecodes_VisitedLessonId",
                table: "Timecodes",
                column: "VisitedLessonId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitedLessons_LessonId",
                table: "VisitedLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitedLessons_MemberId",
                table: "VisitedLessons",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Timecodes");

            migrationBuilder.DropTable(
                name: "VisitedLessons");
        }
    }
}
