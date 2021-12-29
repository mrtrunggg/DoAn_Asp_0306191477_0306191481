using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public string LoaiTk { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKHau { get; set; }
        public string Email { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string SoTK { get; set; }
        public DateTime NgaySinh { get; set; }
        public string HinhDaiDien { get; set; }
        public bool TinhTrang { get; set; }
        public List<HoaDon> HoaDons { get; set; }
    }
}
