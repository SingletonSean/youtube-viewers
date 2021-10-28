using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouTubeViewers.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YouTubeViewers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    IsSubscribed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsMember = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YouTubeViewers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YouTubeViewers");
        }
    }
}
