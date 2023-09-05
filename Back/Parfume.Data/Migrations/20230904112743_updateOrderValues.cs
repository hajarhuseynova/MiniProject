using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class updateOrderValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayinHomewhithCard",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "inHome",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "inMarket",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "isCash",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "withCard",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "What",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Where",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "What",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Where",
                table: "Orders");

            migrationBuilder.AddColumn<bool>(
                name: "PayinHomewhithCard",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inHome",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "inMarket",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isCash",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "withCard",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
