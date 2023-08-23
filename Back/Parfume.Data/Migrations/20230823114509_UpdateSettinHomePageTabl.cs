using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class UpdateSettinHomePageTabl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DislikeP");

            migrationBuilder.DropTable(
                name: "LikeP");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "CommentP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ParfumId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RatingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentP_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CommentP_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DislikeP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: true),
                    CountDislike = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DislikeP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DislikeP_CommentP_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LikeP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: true),
                    CountLike = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LikeP_CommentP_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentP",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentPId = table.Column<int>(type: "int", nullable: true),
                    ParfumId = table.Column<int>(type: "int", nullable: true),
                    AvarageRating = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RatingCount = table.Column<double>(type: "float", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_CommentP_CommentPId",
                        column: x => x.CommentPId,
                        principalTable: "CommentP",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rating_Parfums_ParfumId",
                        column: x => x.ParfumId,
                        principalTable: "Parfums",
                        principalColumn: "Id");
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
                name: "IX_Rating_CommentPId",
                table: "Rating",
                column: "CommentPId",
                unique: true,
                filter: "[CommentPId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_ParfumId",
                table: "Rating",
                column: "ParfumId",
                unique: true,
                filter: "[ParfumId] IS NOT NULL");
        }
    }
}
