using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class SettingFooterTableUpdatesecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title1Link",
                table: "SettingFooter");

            migrationBuilder.DropColumn(
                name: "Title2Link",
                table: "SettingFooter");

            migrationBuilder.DropColumn(
                name: "Title3Link",
                table: "SettingFooter");

            migrationBuilder.DropColumn(
                name: "Title4Link",
                table: "SettingFooter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title1Link",
                table: "SettingFooter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title2Link",
                table: "SettingFooter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title3Link",
                table: "SettingFooter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title4Link",
                table: "SettingFooter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
