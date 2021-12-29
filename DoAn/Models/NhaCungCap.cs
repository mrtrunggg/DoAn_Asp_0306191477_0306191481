using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class NhaCungCap
    {
        public int Id { get; set; }
        public string TenNCC { get; set; }
        public string Thongtinlienlac { get; set; }
        public string Diachi { get; set; }
        public string SDT { get; set; }
        public bool TinhTrang { get; set; }
        public List<SanPham> SanPhams { get; set; }
    }
}
