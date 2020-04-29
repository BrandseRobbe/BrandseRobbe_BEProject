using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Models.Migrations
{
    public partial class guids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "QuizId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GameId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QuizId",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid));
        }
    }
}
