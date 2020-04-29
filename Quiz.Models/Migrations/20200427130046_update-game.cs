using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Models.Migrations
{
    public partial class updategame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<string>(nullable: false),
                    QuizId = table.Column<string>(nullable: true),
                    TimeStarted = table.Column<DateTime>(nullable: false),
                    TimeFinished = table.Column<DateTime>(nullable: true),
                    CorrectAnswers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
