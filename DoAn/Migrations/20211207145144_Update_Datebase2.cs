using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class Update_Datebase2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LoaiSP_SanPhamId",
                table: "SanPhams",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NhaCungCap_SanPhamId",
                table: "SanPhams",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_LoaiSP_SanPhamId",
                table: "SanPhams",
                column: "LoaiSP_SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhams_NhaCungCap_SanPhamId",
                table: "SanPhams",
                column: "NhaCungCap_SanPhamId");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_TaiKhoanId",
                table: "HoaDons",
                column: "TaiKhoanId");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HoaDons_HoaDonId",
                table: "CT_HoaDons",
                column: "HoaDonId");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HoaDons_SanPhamId",
                table: "CT_HoaDons",
                column: "SanPhamId");

            migrationBuilder.AddForeignKey(
                name: "FK_CT_HoaDons_HoaDons_HoaDonId",
                table: "CT_HoaDons",
                column: "HoaDonId",
                principalTable: "HoaDons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CT_HoaDons_SanPhams_SanPhamId",
                table: "CT_HoaDons",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoaDons_TaiKhoan_TaiKhoanId",
                table: "HoaDons",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CT_HoaDons_HoaDons_HoaDonId",
                table: "CT_HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_CT_HoaDons_SanPhams_SanPhamId",
                table: "CT_HoaDons");

            migrationBuilder.DropForeignKey(
                name: "FK_HoaDons_TaiKhoan_TaiKhoanId",
                table: "HoaDons");

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

            migrationBuilder.DropIndex(
                name: "IX_HoaDons_TaiKhoanId",
                table: "HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_CT_HoaDons_HoaDonId",
                table: "CT_HoaDons");

            migrationBuilder.DropIndex(
                name: "IX_CT_HoaDons_SanPhamId",
                table: "CT_HoaDons");

            migrationBuilder.DropColumn(
                name: "LoaiSP_SanPhamId",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "NhaCungCap_SanPhamId",
                table: "SanPhams");
        }
    }
}
