using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class AddYouTubeBroadcastId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YouTubeBroadcastId",
                table: "Lessons",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YouTubeBroadcastId",
                table: "Lessons");
        }
    }
}
