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
        public IActionResult DSSP()
        {
            var sp = _context.SanPhams.ToList();
            ViewBag.ListSP = sp;
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
