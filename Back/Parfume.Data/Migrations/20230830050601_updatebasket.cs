using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class updatebasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParfumVolume",
                table: "BasketItems",
                newName: "TesterId");

            migrationBuilder.AddColumn<int>(
                name: "GiftBoxCount",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GiftBoxId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SmokeCount",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SmokeId",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TesterCount",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_GiftBoxId",
                table: "BasketItems",
                column: "GiftBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_SmokeId",
                table: "BasketItems",
                column: "SmokeId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_TesterId",
                table: "BasketItems",
                column: "TesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_GiftBoxes_GiftBoxId",
                table: "BasketItems",
                column: "GiftBoxId",
                principalTable: "GiftBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Smokes_SmokeId",
                table: "BasketItems",
                column: "SmokeId",
                principalTable: "Smokes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BasketItems_Testers_TesterId",
                table: "BasketItems",
                column: "TesterId",
                principalTable: "Testers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_GiftBoxes_GiftBoxId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Smokes_SmokeId",
                table: "BasketItems");

            migrationBuilder.DropForeignKey(
                name: "FK_BasketItems_Testers_TesterId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_GiftBoxId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_SmokeId",
                table: "BasketItems");

            migrationBuilder.DropIndex(
                name: "IX_BasketItems_TesterId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "GiftBoxCount",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "GiftBoxId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SmokeCount",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "SmokeId",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "TesterCount",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "TesterId",
                table: "BasketItems",
                newName: "ParfumVolume");
        }
    }
}
