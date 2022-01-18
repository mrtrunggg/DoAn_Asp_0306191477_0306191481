using DoAn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using DoAn.Data;


namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        private readonly DoAnContext _context;

        // private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public HomeController(DoAnContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("TaiKhoanTenDangNhap"))
            {
                ViewBag.tendangnhap = HttpContext.Session.GetString("TaiKhoanTenDangNhap");
            }
            return View();          
        }
        public IActionResult Trangchu()
        {
            
            var sp = _context.SanPhams.ToList();
            ViewBag.ListSP = sp;
            return View();
        }
        public IActionResult DSSP(string onhap)
        {
            if (onhap != null)
            {
                var a = _context.SanPhams.Where(s => s.TenSp.Contains(onhap)).ToList();
                ViewBag.ListSP = a;
                return View();
            }
            var sp = _context.SanPhams.ToList();
            ViewBag.ListSP = sp;
            return View();

            
        }
   
       
        public IActionResult add_cart()
        {
            var sp = _context.SanPhams.ToList();
            ViewBag.ListSP = sp;
            return View();
        }
        public IActionResult Giohang()
        {
            var gh = _context.Giohangs.Include(g => g.SanPham).Include(g => g.TaiKhoan);
            ViewBag.ListGH = gh;
            return View();
        }
        

public async Task<IActionResult> CTSP(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams
                .FirstOrDefaultAsync(m => m.Id == id);

            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(string TenDangNhap, string MatKHau)
        {

            TaiKhoan taikhoan = _context.TaiKhoan.Where(a => a.TenDangNhap == TenDangNhap && a.MatKHau == MatKHau && a.LoaiTk != "Admin").FirstOrDefault();

            if (taikhoan != null)
            {

                HttpContext.Session.SetInt32("TaiKhoanId", taikhoan.Id);
                HttpContext.Session.SetString("TaiKhoanTenDangNhap", taikhoan.TenDangNhap);

                return RedirectToAction("TrangChu", "Home");
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
            return RedirectToAction("Login", "Home");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
