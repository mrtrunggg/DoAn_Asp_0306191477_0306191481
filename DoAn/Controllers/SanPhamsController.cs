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
    public class SanPhamsController : Controller
    {
        private readonly DoAnContext _context;

        public SanPhamsController(DoAnContext context)
        {
            _context = context;
        }

        // GET: SanPhams
        public async Task<IActionResult> Index(string timkiemtheo, string onhap, string onhapgiatricuoi)
        {
            var trung = _context.SanPhams.Where(s => s.Dongia >= 40000 && s.Dongia <= 60000).Include(s => s.LoaiSP_SanPham).Include(s => s.NhaCungCap_SanPham).ToList();
            var trung2 = _context.SanPhams.Where(s => s.LoaiSP_SanPham.TenLoaiSP.Contains("Áo")).Include(s => s.LoaiSP_SanPham).Include(s => s.NhaCungCap_SanPham).ToList();
            var trung3 = _context.SanPhams.Where(s => s.SoLuong<=10).Include(s => s.LoaiSP_SanPham).Include(s => s.NhaCungCap_SanPham).ToList();
            //return View(trung);

            if (timkiemtheo == "masp")
            {
                return View(_context.SanPhams.Where(s => s.Id ==int.Parse(onhap)).ToList());
            }
            else if (timkiemtheo == "tensp")
            {
                return View(_context.SanPhams.Where(s => s.TenSp.Contains(onhap)).ToList());
            }
            else if (timkiemtheo == "nhacungcap")
            {
                return View(_context.SanPhams.Where(s => s.NhaCungCap_SanPham.TenNCC.Contains(onhap)).ToList());
            }
            else if (timkiemtheo == "khoanggiatien")
            {
                return View(_context.SanPhams.Where(s => s.Dongia >= int.Parse(onhap) && s.Dongia <= int.Parse(onhapgiatricuoi)).ToList());
            }
            else if (timkiemtheo == "loaisp")
            {
                return View(_context.SanPhams.Where(s => s.LoaiSP_SanPham.TenLoaiSP.Contains(onhap)).ToList());
            }
            else
                return View(await _context.SanPhams.ToListAsync());
        }

        // GET: SanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSP_SanPham)
                .Include(s => s.NhaCungCap_SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // GET: SanPhams/Create
        public IActionResult Create()
        {
            ViewData["LoaiSPId"] = new SelectList(_context.LoaiSPs, "Id", "Id");
            ViewData["NhaCungCapId"] = new SelectList(_context.NhaCungCaps, "Id", "Id");
            return View();
        }

        // POST: SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenSp,Dongia,SoLuong,MoTa,KichThuoc,NhaCungCapId,LoaiSPId,HinhAnh,TinhTrang")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiSPId"] = new SelectList(_context.LoaiSPs, "Id", "Id", sanPham.LoaiSPId);
            ViewData["NhaCungCapId"] = new SelectList(_context.NhaCungCaps, "Id", "Id", sanPham.NhaCungCapId);
            return View(sanPham);
        }

        // GET: SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["LoaiSPId"] = new SelectList(_context.LoaiSPs, "Id", "Id", sanPham.LoaiSPId);
            ViewData["NhaCungCapId"] = new SelectList(_context.NhaCungCaps, "Id", "Id", sanPham.NhaCungCapId);
            return View(sanPham);
        }

        // POST: SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenSp,Dongia,SoLuong,MoTa,KichThuoc,NhaCungCapId,LoaiSPId,HinhAnh,TinhTrang")] SanPham sanPham)
        {
            if (id != sanPham.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.Id))
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
            ViewData["LoaiSPId"] = new SelectList(_context.LoaiSPs, "Id", "Id", sanPham.LoaiSPId);
            ViewData["NhaCungCapId"] = new SelectList(_context.NhaCungCaps, "Id", "Id", sanPham.NhaCungCapId);
            return View(sanPham);
        }

        // GET: SanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .Include(s => s.LoaiSP_SanPham)
                .Include(s => s.NhaCungCap_SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.Id == id);
        }
    }
}
