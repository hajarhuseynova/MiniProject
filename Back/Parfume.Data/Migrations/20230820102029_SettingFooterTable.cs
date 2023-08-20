using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class SettingFooterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageTel",
                table: "SettingContact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageLoc",
                table: "SettingContact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageEmail",
                table: "SettingContact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SettingFooter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title1Par1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title1Par2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2Par1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title2Par2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3Par1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title3Par2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title4Par1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title4Par2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FootIcon1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FootIcon2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FootIcon3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FootIcon4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingFooter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingFooter");

            migrationBuilder.AlterColumn<string>(
                name: "ImageTel",
                table: "SettingContact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageLoc",
                table: "SettingContact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageEmail",
                table: "SettingContact",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
