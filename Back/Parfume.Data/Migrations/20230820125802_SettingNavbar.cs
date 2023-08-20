using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class SettingNavbar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SettingNavbar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hamburger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiderbarP1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiderbarP2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiderbarP3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiderbarP4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiderbarP5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiderbarP6 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingNavbar", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingNavbar");
        }
    }
}
