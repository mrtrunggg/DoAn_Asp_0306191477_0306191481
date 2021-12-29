using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class CT_HoaDon
    {
        public int Id { get; set; }
        public int HoaDonId { get; set; }
        public HoaDon HoaDon { get; set; }
        public int SanPhamId { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
        public int GiaBan { get; set; }
        public bool TinhTrang { get; set; }
    }
}
