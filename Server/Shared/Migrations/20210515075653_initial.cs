using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shared.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserDatas",
                columns: table => new
                {
                    UserdataId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeviceKey = table.Column<string>(type: "TEXT", nullable: true),
                    LogTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDatas", x => x.UserdataId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDatas");
        }
    }
}
