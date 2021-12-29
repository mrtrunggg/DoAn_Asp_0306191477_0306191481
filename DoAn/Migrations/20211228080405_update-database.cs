using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class updatedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_LoaiSPs_LoaiSP_SanPhamId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhaCungCaps_NhaCungCap_SanPhamId",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_LoaiSP_SanPhamId",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_NhaCungCap_SanPhamId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "LoaiSP_SanPhamId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "NhaCungCap_SanPhamId",
                table: "SanPhams");

            migrationBuilder.AddColumn<int>(
                name: "LoaiSPId",
                table: "SanPhams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCapId",
                table: "SanPhams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSPId",
                table: "SanPhams",
                column: "LoaiSPId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_NhaCungCapId",
                table: "SanPhams",
                column: "NhaCungCapId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_LoaiSPs_LoaiSPId",
                table: "SanPhams",
                column: "LoaiSPId",
                principalTable: "LoaiSPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_NhaCungCaps_NhaCungCapId",
                table: "SanPhams",
                column: "NhaCungCapId",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_LoaiSPs_LoaiSPId",
                table: "SanPhams");

            migrationBuilder.DropForeignKey(
                name: "FK_SanPhams_NhaCungCaps_NhaCungCapId",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_LoaiSPId",
                table: "SanPhams");

            migrationBuilder.DropIndex(
                name: "IX_SanPhams_NhaCungCapId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "LoaiSPId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "NhaCungCapId",
                table: "SanPhams");

            migrationBuilder.AddColumn<int>(
                name: "LoaiSP_SanPhamId",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCap_SanPhamId",
                table: "SanPhams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSP_SanPhamId",
                table: "SanPhams",
                column: "LoaiSP_SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_NhaCungCap_SanPhamId",
                table: "SanPhams",
                column: "NhaCungCap_SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_LoaiSPs_LoaiSP_SanPhamId",
                table: "SanPhams",
                column: "LoaiSP_SanPhamId",
                principalTable: "LoaiSPs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SanPhams_NhaCungCaps_NhaCungCap_SanPhamId",
                table: "SanPhams",
                column: "NhaCungCap_SanPhamId",
                principalTable: "NhaCungCaps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
