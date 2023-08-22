using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class CommentRatingLikeDislikeParfumTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParfumId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentPs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentPs_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DislikePs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: true),
                    CountDislike = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DislikePs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DislikePs_CommentPs_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentPs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikePs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: true),
                    CountLike = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikePs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikePs_CommentPs_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentPs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RatingPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvarageRating = table.Column<double>(type: "float", nullable: false),
                    RatingCount = table.Column<double>(type: "float", nullable: false),
                    ParfumId = table.Column<int>(type: "int", nullable: true),
                    CommentPId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RatingPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RatingPs_CommentPs_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentPs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RatingPs_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentPs_AppUserId",
                table: "CommentPs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentPs_ParfumId",
                table: "CommentPs",
                column: "ParfumId");

            migrationBuilder.CreateIndex(
                name: "IX_DislikePs_CommentPId",
                table: "DislikePs",
                column: "CommentPId");

            migrationBuilder.CreateIndex(
                name: "IX_LikePs_CommentPId",
                table: "LikePs",
                column: "CommentPId");

            migrationBuilder.CreateIndex(
                name: "IX_RatingPs_CommentPId",
                table: "RatingPs",
                column: "CommentPId",
                unique: true,
                filter: "[CommentPId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RatingPs_ParfumId",
                table: "RatingPs",
                column: "ParfumId",
                unique: true,
                filter: "[ParfumId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DislikePs");

            migrationBuilder.DropTable(
                name: "LikePs");

            migrationBuilder.DropTable(
                name: "RatingPs");

            migrationBuilder.DropTable(
                name: "CommentPs");
        }
    }
}
