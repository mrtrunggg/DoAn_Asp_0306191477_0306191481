using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public int TaiKhoanId { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public DateTime NgayLapHD { get; set; }
        public DateTime NgayGiaoHang { get; set; }
        public string LoaiHD { get; set; }
        public int TongTien { get; set; }
        public string ThongTinNguoiNhan { get; set; }
        public bool TinhTrang { get; set; }

        public List<CT_HoaDon> CT_HoaDons { get; set; }


    }
}
