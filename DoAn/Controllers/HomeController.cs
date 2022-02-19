﻿using DoAn.Models;
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
            ViewBag.ListSP = _context.SanPhams.ToList();
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

        
        public async Task<IActionResult> giohang()
        {
            if (HttpContext.Session.Keys.Contains("TaiKhoanTenDangNhap"))
            {
                ViewBag.tendangnhap = HttpContext.Session.GetString("TaiKhoanTenDangNhap");
            }
            string username = HttpContext.Session.GetString("TaiKhoanTenDangNhap");
            ViewBag.taikhoan = _context.TaiKhoan.Where(a => a.TenDangNhap == username).FirstOrDefault();
            ViewBag.CartsTotal = _context.Giohangs.Include(c => c.SanPham).Include(c => c.TaiKhoan)
                                                .Where(c => c.TaiKhoan.TenDangNhap == username)
                                                .Sum(c => c.SoLuong * c.SanPham.Dongia);
            ViewBag.ListSP = _context.SanPhams.ToList();
            ViewBag.ListGH = _context.Giohangs.ToList();
            var carts = _context.Giohangs.Include(c => c.TaiKhoan).Include(c => c.SanPham)
                                      .Where(c => c.TaiKhoan.TenDangNhap == username);
            ViewBag.Total = carts.Sum(c => c.SoLuong * c.SanPham.Dongia);
            return View(await carts.ToListAsync());
        }
        public IActionResult themgiohang(int id)
        {
            return themgiohang(id, 1);
        }
        [HttpPost]
        public IActionResult themgiohang(int productId, int quantity)
        {
            if (HttpContext.Session.GetString("TaiKhoanTenDangNhap") != null)
            {
                string username = HttpContext.Session.GetString("TaiKhoanTenDangNhap");
                int accountId = _context.TaiKhoan.FirstOrDefault(a => a.TenDangNhap == username).Id;
                Giohang cart = _context.Giohangs.FirstOrDefault(c => c.TaiKhoanId == accountId && c.SanPhamId == productId);
                if (cart == null)
                {
                    cart = new Giohang();
                    cart.TaiKhoanId = accountId;
                    cart.SanPhamId = productId;
                    cart.SoLuong = quantity;
                    _context.Giohangs.Add(cart);
                }
                else
                {
                    cart.SoLuong += quantity;
                }
                _context.SaveChanges();
                return RedirectToAction("giohang");
            }
            else
            {
                return RedirectToAction("dangnhap", "Home");
            }

        }


        [Route("/RemoveCart/{id:int}", Name = "RemoveCart")]
        public IActionResult RemoveCart([FromRoute] int id)
        {

            Giohang cart = _context.Giohangs.FirstOrDefault();
            var cartitem = _context.Giohangs.Where(p => p.SanPham.Id == id);
            foreach (Giohang c in cartitem)
            {
                _context.Giohangs.Remove(c);
            }
            _context.SaveChanges();
            return RedirectToAction("giohang");
        }

        public IActionResult RemoveAllCart()
        {
            Giohang cart = _context.Giohangs.FirstOrDefault();
            var cartitem = _context.Giohangs;
            foreach (Giohang c in cartitem)
            {
                _context.Giohangs.Remove(c);
            }
            _context.SaveChanges();
            return RedirectToAction("giohang");
        }

        
        [Route("/UpdateCart/{id:int}", Name = "UpdateCart")]
        [HttpPost]
        public IActionResult UpdateCart([FromRoute] int productid, [FromRoute] int quantity)
        {
            Giohang cart = _context.Giohangs.FirstOrDefault();
            var cartitem = _context.Giohangs.Where(p => p.SanPham.Id == productid);
            foreach (Giohang c in cartitem)
            {
                c.SoLuong = quantity;
            }
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        public IActionResult Pay()
        {
            
            string username = HttpContext.Session.GetString("TaiKhoanTenDangNhap");
            ViewBag.taikhoan = _context.TaiKhoan.Where(a => a.TenDangNhap == username).FirstOrDefault();
            ViewBag.CartsTotal = _context.Giohangs.Include(c => c.SanPham).Include(c => c.TaiKhoan)
                                                .Where(c => c.TaiKhoan.TenDangNhap == username)
                                                .Sum(c => c.SoLuong * c.SanPham.Dongia);
            ViewBag.ListSP = _context.SanPhams.ToList();
            ViewBag.ListGH = _context.Giohangs.ToList();
            return View("Pay");
        }
        [HttpPost]
        public IActionResult Pay([Bind("ThongTinNguoiNhan")] HoaDon invoice)
        {
            string username = HttpContext.Session.GetString("TaiKhoanTenDangNhap");
            if (!CheckStock(username))
            {
                ViewBag.ErrorMessage = "Có sản phẩm đã hết hàng. Vui lòng kiểm tra lại";
                ViewBag.Account = _context.TaiKhoan.Where(a => a.TenDangNhap == username).FirstOrDefault();
                ViewBag.CartsTotal = _context.Giohangs.Include(c => c.SanPham).Include(c => c.TaiKhoan)
                                                    .Where(c => c.TaiKhoan.TenDangNhap == username)
                                                    .Sum(c => c.SoLuong * c.SanPham.Dongia);
                return View("Pay");
            }
            //Thêm hoá đơn
            DateTime now = DateTime.Now;
            
            invoice.TaiKhoanId = _context.TaiKhoan.FirstOrDefault(a => a.TenDangNhap == username).Id;
            invoice.NgayLapHD = now;
            invoice.TongTien = _context.Giohangs.Include(c => c.SanPham).Include(c => c.TaiKhoan)
                                                    .Where(c => c.TaiKhoan.TenDangNhap == username)
                                                    .Sum(c => c.SoLuong * c.SanPham.Dongia);
            _context.Add(invoice);
            _context.SaveChanges();
            //Thêm chi tiết hoá đơn
            List<Giohang> carts = _context.Giohangs.Include(c => c.SanPham).Include(c => c.TaiKhoan)
                                                    .Where(c => c.TaiKhoan.TenDangNhap == username).ToList();
            foreach (Giohang c in carts)
            {
                CT_HoaDon invoiceDetail = new CT_HoaDon();
                invoiceDetail.HoaDonId = invoice.Id;
                invoiceDetail.SanPhamId = c.SanPhamId;
                invoiceDetail.SoLuong = c.SoLuong;
                invoiceDetail.GiaBan = c.SanPham.Dongia;
                _context.Add(invoiceDetail);
            }
            _context.SaveChanges();
            //Trừ số lượng tồn kho và xoá giỏ hàng
            foreach (Giohang c in carts)
            {
                c.SanPham.SoLuong -= c.SoLuong;
                _context.Giohangs.Remove(c);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");

        }
        private bool CheckStock(string username)
        {
            List<Giohang> carts = _context.Giohangs.Include(c => c.SanPham).Include(c => c.TaiKhoan)
                                                    .Where(c => c.TaiKhoan.TenDangNhap == username).ToList();
            foreach (Giohang c in carts)
            {
                if (c.SanPham.SoLuong < c.SoLuong)
                {
                    return false;
                }
            }
            return true;
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
        
        public IActionResult Dangnhap()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Dangnhap(string TenDangNhap, string MatKHau)
        {

            TaiKhoan taikhoan = _context.TaiKhoan.Where(a => a.TenDangNhap == TenDangNhap && a.MatKHau == MatKHau && a.LoaiTk != "Admin").FirstOrDefault();

            if (taikhoan != null)
            {

                HttpContext.Session.SetInt32("TaiKhoanId", taikhoan.Id);
                HttpContext.Session.SetString("TaiKhoanTenDangNhap", taikhoan.TenDangNhap);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErroMessage = "1";
                return View();
            }

        }

        public IActionResult dangxuat()
        {
            HttpContext.Session.Remove("TaiKhoanId");
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
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
