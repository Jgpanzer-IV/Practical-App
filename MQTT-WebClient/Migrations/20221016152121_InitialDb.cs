using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MQTT_WebClient.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PublishedMessages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    PublishTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ServerPort = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishedMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscribedMessages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    SubscribTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServerUrl = table.Column<string>(type: "TEXT", nullable: false),
                    ServerPort = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribedMessages", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublishedMessages");

            migrationBuilder.DropTable(
                name: "SubscribedMessages");
        }
    }
}
