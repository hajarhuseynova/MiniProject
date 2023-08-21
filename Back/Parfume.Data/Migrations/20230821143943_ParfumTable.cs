using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class ParfumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testers_Brands_BrandId",
                table: "Testers");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Testers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Parfums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parfums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parfums_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilliLiters = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParfumVolume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumId = table.Column<int>(type: "int", nullable: false),
                    VolumeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParfumVolume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParfumVolume_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParfumVolume_Volume_VolumeId",
                        column: x => x.VolumeId,
                        principalTable: "Volume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Parfums_BrandId",
                table: "Parfums",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ParfumVolume_ParfumId",
                table: "ParfumVolume",
                column: "ParfumId");

            migrationBuilder.CreateIndex(
                name: "IX_ParfumVolume_VolumeId",
                table: "ParfumVolume",
                column: "VolumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Testers_Brands_BrandId",
                table: "Testers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Testers_Brands_BrandId",
                table: "Testers");

            migrationBuilder.DropTable(
                name: "ParfumVolume");

            migrationBuilder.DropTable(
                name: "Parfums");

            migrationBuilder.DropTable(
                name: "Volume");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Testers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Testers_Brands_BrandId",
                table: "Testers",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
