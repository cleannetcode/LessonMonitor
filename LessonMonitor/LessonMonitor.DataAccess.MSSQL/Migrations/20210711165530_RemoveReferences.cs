using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class RemoveReferences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Homeworks_HomeworkId",
                table: "Lessons");

            migrationBuilder.DropTable(
                name: "HomeworkMember");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_HomeworkId",
                table: "Lessons");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Homeworks_LessonId",
                table: "Homeworks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Homeworks_LessonId",
                table: "Homeworks",
                column: "LessonId");

            migrationBuilder.CreateTable(
                name: "HomeworkMember",
                columns: table => new
                {
                    HomeworksId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeworkMember", x => new { x.HomeworksId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_HomeworkMember_Homeworks_HomeworksId",
                        column: x => x.HomeworksId,
                        principalTable: "Homeworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HomeworkMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_HomeworkId",
                table: "Lessons",
                column: "HomeworkId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HomeworkMember_MembersId",
                table: "HomeworkMember",
                column: "MembersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Homeworks_HomeworkId",
                table: "Lessons",
                column: "HomeworkId",
                principalTable: "Homeworks",
                principalColumn: "LessonId");
        }
    }
}
