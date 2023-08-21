using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class VolumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParfumVolume_Volume_VolumeId",
                table: "ParfumVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volume",
                table: "Volume");

            migrationBuilder.RenameTable(
                name: "Volume",
                newName: "Volumes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volumes",
                table: "Volumes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumVolume_Volumes_VolumeId",
                table: "ParfumVolume",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParfumVolume_Volumes_VolumeId",
                table: "ParfumVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volumes",
                table: "Volumes");

            migrationBuilder.RenameTable(
                name: "Volumes",
                newName: "Volume");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volume",
                table: "Volume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumVolume_Volume_VolumeId",
                table: "ParfumVolume",
                column: "VolumeId",
                principalTable: "Volume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
