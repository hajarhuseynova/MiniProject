using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class UpdateSettinHomePageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentPs_AspNetUsers_AppUserId",
                table: "CommentPs");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentPs_Parfums_ParfumId",
                table: "CommentPs");

            migrationBuilder.DropForeignKey(
                name: "FK_DislikePs_CommentPs_CommentPId",
                table: "DislikePs");

            migrationBuilder.DropForeignKey(
                name: "FK_LikePs_CommentPs_CommentPId",
                table: "LikePs");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingPs_CommentPs_CommentPId",
                table: "RatingPs");

            migrationBuilder.DropForeignKey(
                name: "FK_RatingPs_Parfums_ParfumId",
                table: "RatingPs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RatingPs",
                table: "RatingPs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikePs",
                table: "LikePs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DislikePs",
                table: "DislikePs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentPs",
                table: "CommentPs");

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

            migrationBuilder.RenameTable(
                name: "RatingPs",
                newName: "Rating");

            migrationBuilder.RenameTable(
                name: "LikePs",
                newName: "LikeP");

            migrationBuilder.RenameTable(
                name: "DislikePs",
                newName: "DislikeP");

            migrationBuilder.RenameTable(
                name: "CommentPs",
                newName: "CommentP");

            migrationBuilder.RenameIndex(
                name: "IX_RatingPs_ParfumId",
                table: "Rating",
                newName: "IX_Rating_ParfumId");

            migrationBuilder.RenameIndex(
                name: "IX_RatingPs_CommentPId",
                table: "Rating",
                newName: "IX_Rating_CommentPId");

            migrationBuilder.RenameIndex(
                name: "IX_LikePs_CommentPId",
                table: "LikeP",
                newName: "IX_LikeP_CommentPId");

            migrationBuilder.RenameIndex(
                name: "IX_DislikePs_CommentPId",
                table: "DislikeP",
                newName: "IX_DislikeP_CommentPId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentPs_ParfumId",
                table: "CommentP",
                newName: "IX_CommentP_ParfumId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentPs_AppUserId",
                table: "CommentP",
                newName: "IX_CommentP_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "DescSmoke",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageSmoke",
                table: "SettingHomePage",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rating",
                table: "Rating",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeP",
                table: "LikeP",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DislikeP",
                table: "DislikeP",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentP",
                table: "CommentP",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentP_AspNetUsers_AppUserId",
                table: "CommentP",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentP_Parfums_ParfumId",
                table: "CommentP",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DislikeP_CommentP_CommentPId",
                table: "DislikeP",
                column: "CommentPId",
                principalTable: "CommentP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeP_CommentP_CommentPId",
                table: "LikeP",
                column: "CommentPId",
                principalTable: "CommentP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_CommentP_CommentPId",
                table: "Rating",
                column: "CommentPId",
                principalTable: "CommentP",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Parfums_ParfumId",
                table: "Rating",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentP_AspNetUsers_AppUserId",
                table: "CommentP");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentP_Parfums_ParfumId",
                table: "CommentP");

            migrationBuilder.DropForeignKey(
                name: "FK_DislikeP_CommentP_CommentPId",
                table: "DislikeP");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeP_CommentP_CommentPId",
                table: "LikeP");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_CommentP_CommentPId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Parfums_ParfumId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeP",
                table: "LikeP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DislikeP",
                table: "DislikeP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentP",
                table: "CommentP");

            migrationBuilder.DropColumn(
                name: "DescSmoke",
                table: "SettingHomePage");

            migrationBuilder.DropColumn(
                name: "ImageSmoke",
                table: "SettingHomePage");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "RatingPs");

            migrationBuilder.RenameTable(
                name: "LikeP",
                newName: "LikePs");

            migrationBuilder.RenameTable(
                name: "DislikeP",
                newName: "DislikePs");

            migrationBuilder.RenameTable(
                name: "CommentP",
                newName: "CommentPs");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_ParfumId",
                table: "RatingPs",
                newName: "IX_RatingPs_ParfumId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_CommentPId",
                table: "RatingPs",
                newName: "IX_RatingPs_CommentPId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeP_CommentPId",
                table: "LikePs",
                newName: "IX_LikePs_CommentPId");

            migrationBuilder.RenameIndex(
                name: "IX_DislikeP_CommentPId",
                table: "DislikePs",
                newName: "IX_DislikePs_CommentPId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentP_ParfumId",
                table: "CommentPs",
                newName: "IX_CommentPs_ParfumId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentP_AppUserId",
                table: "CommentPs",
                newName: "IX_CommentPs_AppUserId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_RatingPs",
                table: "RatingPs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikePs",
                table: "LikePs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DislikePs",
                table: "DislikePs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentPs",
                table: "CommentPs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPs_AspNetUsers_AppUserId",
                table: "CommentPs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentPs_Parfums_ParfumId",
                table: "CommentPs",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DislikePs_CommentPs_CommentPId",
                table: "DislikePs",
                column: "CommentPId",
                principalTable: "CommentPs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikePs_CommentPs_CommentPId",
                table: "LikePs",
                column: "CommentPId",
                principalTable: "CommentPs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingPs_CommentPs_CommentPId",
                table: "RatingPs",
                column: "CommentPId",
                principalTable: "CommentPs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RatingPs_Parfums_ParfumId",
                table: "RatingPs",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id");
        }
    }
}
