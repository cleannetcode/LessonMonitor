using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LessonMonitor.DataAccess.MSSQL.Migrations
{
    public partial class ChangeTypeOfGithubAccountId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GithubAccountId",
                table: "GithubAccounts");

            migrationBuilder.AddColumn<int>(
                name: "GithubAccountId",
                table: "GithubAccounts",
                type: "int",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
             name: "GithubAccountId",
             table: "GithubAccounts");

            migrationBuilder.AddColumn<int>(
               name: "GithubAccountId",
               table: "GithubAccounts",
               type: "uniqueidentifier",
               nullable: false);
        }
    }
}
