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
    public class GiohangsController : Controller
    {
        private readonly DoAnContext _context;

        public GiohangsController(DoAnContext context)
        {
            _context = context;
        }

        // GET: Giohangs
        public async Task<IActionResult> Index()
        {
            var doAnContext = _context.Giohangs.Include(g => g.SanPham).Include(g => g.TaiKhoan);
            return View(await doAnContext.ToListAsync());
        }

        // GET: Giohangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohangs
                .Include(g => g.SanPham)
                .Include(g => g.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // GET: Giohangs/Create
        public IActionResult Create()
        {
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id");
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id");
            return View();
        }

        // POST: Giohangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaiKhoanId,SanPhamId,SoLuong")] Giohang giohang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giohang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", giohang.SanPhamId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id", giohang.TaiKhoanId);
            return View(giohang);
        }

        // GET: Giohangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohangs.FindAsync(id);
            if (giohang == null)
            {
                return NotFound();
            }
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", giohang.SanPhamId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id", giohang.TaiKhoanId);
            return View(giohang);
        }

        // POST: Giohangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaiKhoanId,SanPhamId,SoLuong")] Giohang giohang)
        {
            if (id != giohang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giohang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiohangExists(giohang.Id))
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
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", giohang.SanPhamId);
            ViewData["TaiKhoanId"] = new SelectList(_context.TaiKhoan, "Id", "Id", giohang.TaiKhoanId);
            return View(giohang);
        }

        // GET: Giohangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohangs
                .Include(g => g.SanPham)
                .Include(g => g.TaiKhoan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // POST: Giohangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giohang = await _context.Giohangs.FindAsync(id);
            _context.Giohangs.Remove(giohang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiohangExists(int id)
        {
            return _context.Giohangs.Any(e => e.Id == id);
        }
    }
}
