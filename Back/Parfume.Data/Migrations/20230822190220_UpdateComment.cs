using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class UpdateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "star1",
                table: "CommentPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "star2",
                table: "CommentPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "star3",
                table: "CommentPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "star4",
                table: "CommentPs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "star5",
                table: "CommentPs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "star1",
                table: "CommentPs");

            migrationBuilder.DropColumn(
                name: "star2",
                table: "CommentPs");

            migrationBuilder.DropColumn(
                name: "star3",
                table: "CommentPs");

            migrationBuilder.DropColumn(
                name: "star4",
                table: "CommentPs");

            migrationBuilder.DropColumn(
                name: "star5",
                table: "CommentPs");
        }
    }
}
