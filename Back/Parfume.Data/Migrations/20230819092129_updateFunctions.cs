using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class updateFunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Icon",
                table: "Functions",
                newName: "Link");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Functions",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Functions");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Functions",
                newName: "Icon");
        }
    }
}
