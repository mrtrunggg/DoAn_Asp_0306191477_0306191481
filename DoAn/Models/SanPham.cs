using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string TenSp { get; set; }
        public int Dongia { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public string KichThuoc { get; set; }
        public int NhaCungCapId { get; set; }
        public NhaCungCap NhaCungCap_SanPham { get; set; }
        public int LoaiSPId { get; set; }
        public LoaiSP LoaiSP_SanPham { get; set; }
        public string HinhAnh { get; set; }

        
        public bool TinhTrang { get; set; }
        public List<CT_HoaDon> CT_HoaDons { get; set; }
    }
}
