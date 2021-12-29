using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAn.Migrations
{
    public partial class Update_Database3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaSp",
                table: "SanPhams");

            migrationBuilder.DropColumn(
                name: "MaNCC",
                table: "NhaCungCaps");

            migrationBuilder.DropColumn(
                name: "MaLoaiSP",
                table: "LoaiSPs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaSp",
                table: "SanPhams",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaNCC",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaLoaiSP",
                table: "LoaiSPs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
