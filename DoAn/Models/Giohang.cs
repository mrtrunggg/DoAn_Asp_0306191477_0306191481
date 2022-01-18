
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DoAn.Models
{
    public class Giohang
    {
        public int Id { get; set; }
        public int TaiKhoanId { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }

    }

    
}
