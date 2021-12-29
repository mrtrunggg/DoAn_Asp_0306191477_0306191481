using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn.Models
{
    public class LoaiSP
    {
        public int Id { get; set; }
        public string TenLoaiSP { get; set; }     
        public string MoTa { get; set; }
        public bool TinhTrang { get; set; }

        public List<SanPham> SanPhams { get; set; }
    }
}
