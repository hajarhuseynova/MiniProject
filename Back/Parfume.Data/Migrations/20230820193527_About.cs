using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class About : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageTester",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageGift2",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageGift1",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SettingAbout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageWho1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageWho2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageWhy1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageWhy2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoP1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoP2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhoP3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhyTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhyP1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhyP2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconP1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconP2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconP3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconP4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingAbout", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingAbout");

            migrationBuilder.AlterColumn<string>(
                name: "ImageTester",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageGift2",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageGift1",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
