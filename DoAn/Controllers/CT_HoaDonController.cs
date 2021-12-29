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
    public class CT_HoaDonController : Controller
    {
        private readonly DoAnContext _context;

        public CT_HoaDonController(DoAnContext context)
        {
            _context = context;
        }

        // GET: CT_HoaDon
        public async Task<IActionResult> Index(string timkiemtheo, string onhap, string onhap2)
        {
            var doAnContext = _context.CT_HoaDons.Include(c => c.HoaDon).Include(c => c.SanPham);
            //return View(await doAnContext.ToListAsync());

            if (timkiemtheo == "hdid")
            {
                return View(_context.CT_HoaDons.Where(s => s.HoaDonId == int.Parse(onhap)).Include(c => c.HoaDon).Include(c => c.SanPham).ToList());
            }
            else if (timkiemtheo == "spid")
            {
                return View(_context.CT_HoaDons.Where(s => s.SanPhamId == int.Parse(onhap)).Include(c => c.HoaDon).Include(c => c.SanPham).ToList());
            }
            else if (timkiemtheo == "giaban")
            {
                return View(_context.CT_HoaDons.Where(s => s.GiaBan >= int.Parse(onhap) && s.GiaBan <= int.Parse(onhap2)).Include(c => c.HoaDon).Include(c => c.SanPham).ToList());
            }
            else if (timkiemtheo == "sl")
            {
                return View(_context.CT_HoaDons.Where(s => s.SoLuong == int.Parse(onhap)).Include(c => c.HoaDon).Include(c => c.SanPham).ToList());
            }
            else
                return View(await doAnContext.ToListAsync());
        }

        // GET: CT_HoaDon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_HoaDon = await _context.CT_HoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cT_HoaDon == null)
            {
                return NotFound();
            }

            return View(cT_HoaDon);
        }

        // GET: CT_HoaDon/Create
        public IActionResult Create()
        {
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "Id", "Id");
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id");
            return View();
        }

        // POST: CT_HoaDon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,HoaDonId,SanPhamId,SoLuong,GiaBan,TinhTrang")] CT_HoaDon cT_HoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cT_HoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "Id", "Id", cT_HoaDon.HoaDonId);
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", cT_HoaDon.SanPhamId);
            return View(cT_HoaDon);
        }

        // GET: CT_HoaDon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_HoaDon = await _context.CT_HoaDons.FindAsync(id);
            if (cT_HoaDon == null)
            {
                return NotFound();
            }
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "Id", "Id", cT_HoaDon.HoaDonId);
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", cT_HoaDon.SanPhamId);
            return View(cT_HoaDon);
        }

        // POST: CT_HoaDon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,HoaDonId,SanPhamId,SoLuong,GiaBan,TinhTrang")] CT_HoaDon cT_HoaDon)
        {
            if (id != cT_HoaDon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cT_HoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CT_HoaDonExists(cT_HoaDon.Id))
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
            ViewData["HoaDonId"] = new SelectList(_context.HoaDons, "Id", "Id", cT_HoaDon.HoaDonId);
            ViewData["SanPhamId"] = new SelectList(_context.SanPhams, "Id", "Id", cT_HoaDon.SanPhamId);
            return View(cT_HoaDon);
        }

        // GET: CT_HoaDon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cT_HoaDon = await _context.CT_HoaDons
                .Include(c => c.HoaDon)
                .Include(c => c.SanPham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cT_HoaDon == null)
            {
                return NotFound();
            }

            return View(cT_HoaDon);
        }

        // POST: CT_HoaDon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cT_HoaDon = await _context.CT_HoaDons.FindAsync(id);
            _context.CT_HoaDons.Remove(cT_HoaDon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CT_HoaDonExists(int id)
        {
            return _context.CT_HoaDons.Any(e => e.Id == id);
        }
    }
}
