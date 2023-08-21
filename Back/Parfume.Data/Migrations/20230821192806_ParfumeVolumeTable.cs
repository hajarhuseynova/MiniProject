using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parfume.Data.Migrations
{
    public partial class ParfumeVolumeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parfums_Brands_BrandId",
                table: "Parfums");

            migrationBuilder.DropForeignKey(
                name: "FK_ParfumVolume_Parfums_ParfumId",
                table: "ParfumVolume");

            migrationBuilder.DropForeignKey(
                name: "FK_ParfumVolume_Volumes_VolumeId",
                table: "ParfumVolume");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParfumVolume",
                table: "ParfumVolume");

            migrationBuilder.RenameTable(
                name: "ParfumVolume",
                newName: "ParfumeVolumes");

            migrationBuilder.RenameIndex(
                name: "IX_ParfumVolume_VolumeId",
                table: "ParfumeVolumes",
                newName: "IX_ParfumeVolumes_VolumeId");

            migrationBuilder.RenameIndex(
                name: "IX_ParfumVolume_ParfumId",
                table: "ParfumeVolumes",
                newName: "IX_ParfumeVolumes_ParfumId");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Parfums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParfumeVolumes",
                table: "ParfumeVolumes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumeVolumes_Parfums_ParfumId",
                table: "ParfumeVolumes",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumeVolumes_Volumes_VolumeId",
                table: "ParfumeVolumes",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parfums_Brands_BrandId",
                table: "Parfums",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParfumeVolumes_Parfums_ParfumId",
                table: "ParfumeVolumes");

            migrationBuilder.DropForeignKey(
                name: "FK_ParfumeVolumes_Volumes_VolumeId",
                table: "ParfumeVolumes");

            migrationBuilder.DropForeignKey(
                name: "FK_Parfums_Brands_BrandId",
                table: "Parfums");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParfumeVolumes",
                table: "ParfumeVolumes");

            migrationBuilder.RenameTable(
                name: "ParfumeVolumes",
                newName: "ParfumVolume");

            migrationBuilder.RenameIndex(
                name: "IX_ParfumeVolumes_VolumeId",
                table: "ParfumVolume",
                newName: "IX_ParfumVolume_VolumeId");

            migrationBuilder.RenameIndex(
                name: "IX_ParfumeVolumes_ParfumId",
                table: "ParfumVolume",
                newName: "IX_ParfumVolume_ParfumId");

            migrationBuilder.AlterColumn<int>(
                name: "BrandId",
                table: "Parfums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParfumVolume",
                table: "ParfumVolume",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Parfums_Brands_BrandId",
                table: "Parfums",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumVolume_Parfums_ParfumId",
                table: "ParfumVolume",
                column: "ParfumId",
                principalTable: "Parfums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParfumVolume_Volumes_VolumeId",
                table: "ParfumVolume",
                column: "VolumeId",
                principalTable: "Volumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
