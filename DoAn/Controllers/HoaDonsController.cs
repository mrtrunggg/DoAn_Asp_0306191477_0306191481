using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn.Data;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class HoaDonsController : Controller
    {
        private readonly DoAnContext _context;

        public HoaDonsController(DoAnContext context)
        {
            _context = context;
        }

        // GET: HoaDons
        public async Task<IActionResult> Index(string timkiemtheo, string onhap, string onhap2)
        {
            //var trung = _context.HoaDons.Where(s => s.TongTien >= 400000 && s.TongTien <= 600000).Include(h => h.TaiKhoan).ToList();


            //var trung3 = from HD in _context.HoaDons
            //         join TK in _context.TaiKhoan
            //         on HD.TaiKhoanId equals TK.Id
            //         where TK.DiaChi.Contains( "Tp.Hồ Chí Minh")
            //         select HD;
            //return View(trung3);

            //var trung4 = from HD in _context.HoaDons
            //             join TK in _context.TaiKhoan
            //             on HD.TaiKhoanId equals TK.Id
            //             where TK.TenDangNhap.Contains("tuan")
            //             select HD;
            //return View(trung4);

            //var trung5 = from HD in _context.HoaDons
            //             join CT_HD in _context.CT_HoaDons on HD.Id equals CT_HD.HoaDonId
            //             join SP in _context.SanPhams on CT_HD.SanPhamId equals SP.Id
            //             where CT_HD.SanPhamId == 9 && CT_HD.SoLuong >15
            //             select HD;
            ////return View(trung5);

            //var trung6 = from HD in _context.HoaDons
            //             join CT_HD in _context.CT_HoaDons on HD.Id equals CT_HD.HoaDonId
            //             join SP in _context.SanPhams on CT_HD.SanPhamId equals SP.Id
            //             where SP.LoaiSP_SanPham.TenLoaiSP.Contains("Giày") || SP.LoaiSP_SanPham.TenLoaiSP.Contains("Áo") 
            //             select HD;
            //return View(trung6);


            //var doAnContext = _context.HoaDons.Include(h => h.TaiKhoan);
            //return View(await _context.HoaDons.ToListAsync());
            //return View(trung);


            if (timkiemtheo == "tk")
            {
                return View(_context.HoaDons.Where(s => s.TaiKhoanId == int.Parse(onhap)).ToList());
            }
            else if (timkiemtheo == "Loaihd")
            {
                return View(_context.HoaDons.Where(s => s.LoaiHD.Contains(onhap)).ToList());
            }
            else if (timkiemtheo == "tongtien")
            {
                return View(_context.HoaDons.Where(s => s.TongTien >= int.Parse(onhap) && s.TongTien<= int.Parse(onhap2)).ToList()) ;
            }
            else if (timkiemtheo == "thongtinnguoinhan")
            {
                return View(_context.HoaDons.Where(s => s.ThongTinNguoiNhan.Contains(onhap)).ToList());
            }         
            else
                return View(await _context.HoaDons.ToListAsync());
        }

        // GET: HoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public IActionResult Create()
        {
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaiKhoanId,NgayLapHD,NgayGiaoHang,LoaiHD,TongTien,ThongTinNguoiNhan,TinhTrang")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id", hoaDon.TaiKhoanId);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons.FindAsync(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id", hoaDon.TaiKhoanId);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoanId,NgayLapHD,NgayGiaoHang,LoaiHD,TongTien,ThongTinNguoiNhan,TinhTrang")] HoaDon hoaDon)
        {
            if (id != hoaDon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id", hoaDon.TaiKhoanId);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hoaDon = await _context.HoaDons
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDons.FindAsync(id);
            _context.HoaDons.Remove(hoaDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDons.Any(e => e.Id == id);
        }
    }
}
