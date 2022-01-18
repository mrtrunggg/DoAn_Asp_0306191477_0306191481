using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAn.Data;
using DoAn.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace DoAn.Controllers
{
    public class TaiKhoansController : Controller
    {
        private readonly DoAnContext _context;

        public TaiKhoansController(DoAnContext context)
        {
            _context = context;
        }

        // GET: TaiKhoans
        public async Task<IActionResult> Index(string timkiemtheo, string onhap)
        {
            //var trung = _context.TaiKhoan.Where(n => n.Email.Contains("@Gmail")).Where(n => n.DiaChi.Contains("Tp.Hồ Chí Minh")).ToList();
             //var trung2 = _context.TaiKhoan.Where(n => n.DiaChi.Contains("Tp.Hồ Chí Minh")).ToList();
            if (timkiemtheo == "tendangnhap")
            {
                return View(_context.TaiKhoan.Where(s => s.TenDangNhap.Contains(onhap)).ToList());
            } else if(timkiemtheo == "email")
            {
                return View(_context.TaiKhoan.Where(s => s.Email.Contains(onhap)).ToList());
            }
            else if (timkiemtheo == "sdt")
            {
                return View(_context.TaiKhoan.Where(s => s.SoDT.Contains(onhap)).ToList());
            }
            else if (timkiemtheo == "diachi")
            {
                return View(_context.TaiKhoan.Where(s => s.DiaChi.Contains(onhap)).ToList());
            }
            else if (timkiemtheo == "hoten")
            {
                return View(_context.TaiKhoan.Where(s => s.HoTen.Contains(onhap)).ToList());
            }else               
            return View(await _context.TaiKhoan.ToListAsync());
            
        }

        // GET: TaiKhoans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return View(taiKhoan);
        }


        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(string TenDangNhap, string MatKHau)
        {

            TaiKhoan taikhoan = _context.TaiKhoan.Where(a => a.TenDangNhap == TenDangNhap && a.MatKHau == MatKHau).FirstOrDefault();

            if (taikhoan != null)
            {
                
                HttpContext.Session.SetInt32("TaiKhoanId", taikhoan.Id);
                HttpContext.Session.SetString("TaiKhoanTenDangNhap", taikhoan.TenDangNhap);

                return RedirectToAction("TrangChu", "SanPhams");
            }
            else
            {
                ViewBag.ErroMessage = "Dang nhap that bai";
                return View();
            }

        }


        public IActionResult logout()
        {
            HttpContext.Session.Remove("TaiKhoanId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }




        // GET: TaiKhoans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaiKhoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LoaiTk,TenDangNhap,MatKHau,Email,HoTen,DiaChi,SoDT,SoTK,NgaySinh,HinhDaiDien,TinhTrang")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiKhoan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan.FindAsync(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LoaiTk,TenDangNhap,MatKHau,Email,HoTen,DiaChi,SoDT,SoTK,NgaySinh,HinhDaiDien,TinhTrang")] TaiKhoan taiKhoan)
        {
            if (id != taiKhoan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiKhoan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiKhoanExists(taiKhoan.Id))
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
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taiKhoan = await _context.TaiKhoan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            return View(taiKhoan);
        }

        // POST: TaiKhoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taiKhoan = await _context.TaiKhoan.FindAsync(id);
            _context.TaiKhoan.Remove(taiKhoan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiKhoanExists(int id)
        {
            return _context.TaiKhoan.Any(e => e.Id == id);
        }
    }
}
