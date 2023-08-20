using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class SettingHome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BottleSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Milliliters = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BottleSize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
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
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Parfum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    SellPrice = table.Column<double>(type: "float", nullable: false),
                    CountSell = table.Column<int>(type: "int", nullable: false),
                    TimeSell = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Info2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isNew = table.Column<bool>(type: "bit", nullable: false),
                    isTrend = table.Column<bool>(type: "bit", nullable: false),
                    isDiscount = table.Column<bool>(type: "bit", nullable: false),
                    isStock = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPrice = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parfum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parfum_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentP_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentP_Parfum_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParfumBottleSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumId = table.Column<int>(type: "int", nullable: false),
                    BottleSizeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParfumBottleSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParfumBottleSize_BottleSize_BottleSizeId",
                        column: x => x.BottleSizeId,
                        principalTable: "BottleSize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParfumBottleSize_Parfum_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DislikeP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DislikeP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DislikeP_CommentP_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeP_CommentP_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvarageRating = table.Column<double>(type: "float", nullable: false),
                    RatingCount = table.Column<double>(type: "float", nullable: false),
                    ParfumId = table.Column<int>(type: "int", nullable: false),
                    CommentPId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_CommentP_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_Parfum_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfum",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentP_AppUserId",
                table: "CommentP",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentP_ParfumId",
                table: "CommentP",
                column: "ParfumId");

            migrationBuilder.CreateIndex(
                name: "IX_DislikeP_CommentPId",
                table: "DislikeP",
                column: "CommentPId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeP_CommentPId",
                table: "LikeP",
                column: "CommentPId");

            migrationBuilder.CreateIndex(
                name: "IX_Parfum_BrandId",
                table: "Parfum",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ParfumBottleSize_BottleSizeId",
                table: "ParfumBottleSize",
                column: "BottleSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParfumBottleSize_ParfumId",
                table: "ParfumBottleSize",
                column: "ParfumId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_CommentPId",
                table: "Rating",
                column: "CommentPId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ParfumId",
                table: "Rating",
                column: "ParfumId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DislikeP");

            migrationBuilder.DropTable(
                name: "LikeP");

            migrationBuilder.DropTable(
                name: "ParfumBottleSize");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "SettingHomePage");

            migrationBuilder.DropTable(
                name: "BottleSize");

            migrationBuilder.DropTable(
                name: "CommentP");

            migrationBuilder.DropTable(
                name: "Parfum");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
