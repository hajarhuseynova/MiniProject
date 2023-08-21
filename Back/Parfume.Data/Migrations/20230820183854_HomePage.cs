using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class HomePage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SettingHomePage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleGift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionGift = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGift1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGift2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescTester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageTester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingHomePage", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingHomePage");
        }
    }
}
