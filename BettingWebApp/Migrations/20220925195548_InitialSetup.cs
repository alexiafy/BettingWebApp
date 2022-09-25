using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingWebApp.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    MatchDate = table.Column<DateTime>(nullable: false),
                    MatchTime = table.Column<DateTime>(nullable: false),
                    TeamA = table.Column<string>(maxLength: 100, nullable: false),
                    TeamB = table.Column<string>(maxLength: 100, nullable: false),
                    Sport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MatchOdd",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchID = table.Column<int>(nullable: false),
                    Specifier = table.Column<string>(maxLength: 500, nullable: false),
                    Odd = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchOdd", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "MatchOdd");
        }
    }
}
