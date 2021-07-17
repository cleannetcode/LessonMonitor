using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class CreateRelationForLessonAndHomework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeworkId",
                table: "Lessons");

            migrationBuilder.AddForeignKey(
                name: "FK_Homeworks_Lessons_LessonId",
                table: "Homeworks",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.Sql(@"CREATE VIEW [dbo].[LessonsView]
				AS
				SELECT        Id, Title, Description, StartDate
				FROM            dbo.Lessons
				GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Homeworks_Lessons_LessonId",
                table: "Homeworks");

            migrationBuilder.AddColumn<int>(
                name: "HomeworkId",
                table: "Lessons",
                type: "int",
                nullable: true);
        }
    }
}
