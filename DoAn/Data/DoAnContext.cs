using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoAn.Models;
namespace DoAn.Data
{
    public class DoAnContext:DbContext
    {
        public DoAnContext(DbContextOptions<DoAnContext> options)
       : base(options)
        {
        }


        public DbSet<CT_HoaDon> CT_HoaDons { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<LoaiSP> LoaiSPs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<TaiKhoan> TaiKhoan { get; set; }
        public DbSet<Giohang> Giohangs { get; set; }
    }
}
