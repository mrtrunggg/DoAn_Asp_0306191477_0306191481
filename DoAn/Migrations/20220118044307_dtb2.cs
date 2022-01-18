using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class dtb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Giohang_SanPhams_SanPhamId",
                table: "Giohang");

            migrationBuilder.DropForeignKey(
                name: "FK_Giohang_TaiKhoan_TaiKhoanId",
                table: "Giohang");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Giohang",
                table: "Giohang");

            migrationBuilder.RenameTable(
                name: "Giohang",
                newName: "Giohangs");

            migrationBuilder.RenameIndex(
                name: "IX_Giohang_TaiKhoanId",
                table: "Giohangs",
                newName: "IX_Giohangs_TaiKhoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Giohang_SanPhamId",
                table: "Giohangs",
                newName: "IX_Giohangs_SanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Giohangs",
                table: "Giohangs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Giohangs_SanPhams_SanPhamId",
                table: "Giohangs",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Giohangs_TaiKhoan_TaiKhoanId",
                table: "Giohangs",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Giohangs_SanPhams_SanPhamId",
                table: "Giohangs");

            migrationBuilder.DropForeignKey(
                name: "FK_Giohangs_TaiKhoan_TaiKhoanId",
                table: "Giohangs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Giohangs",
                table: "Giohangs");

            migrationBuilder.RenameTable(
                name: "Giohangs",
                newName: "Giohang");

            migrationBuilder.RenameIndex(
                name: "IX_Giohangs_TaiKhoanId",
                table: "Giohang",
                newName: "IX_Giohang_TaiKhoanId");

            migrationBuilder.RenameIndex(
                name: "IX_Giohangs_SanPhamId",
                table: "Giohang",
                newName: "IX_Giohang_SanPhamId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Giohang",
                table: "Giohang",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Giohang_SanPhams_SanPhamId",
                table: "Giohang",
                column: "SanPhamId",
                principalTable: "SanPhams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Giohang_TaiKhoan_TaiKhoanId",
                table: "Giohang",
                column: "TaiKhoanId",
                principalTable: "TaiKhoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
