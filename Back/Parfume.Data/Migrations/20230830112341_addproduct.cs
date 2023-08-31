using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class addproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TesterId",
                table: "BasketItems");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false),
                    IsTrend = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscount = table.Column<bool>(type: "bit", nullable: false),
                    IsStock = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountSell = table.Column<int>(type: "int", nullable: true),
                    TimeSell = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Category_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProperties",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PropertyKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProperties", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ProductProperties_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProperties");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");

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

            migrationBuilder.AddColumn<int>(
                name: "TesterId",
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
    }
}
