using Microsoft.AspNetCore.Mvc;
using WebsiteHotelManagerment.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebsiteHotelManagerment.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context; // thêm DbContext
        private const string CartSessionKey = "CartSession";

        public PaymentController(ApplicationDbContext context)  // khởi tạo DbContext qua DI
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(int ChiTietPhongId, string HoTen, string SoDienThoai,
            DateTime NgayNhan, DateTime NgayTra, int NguoiLon, int TreEm, decimal TongTien)
        {
            if (NgayTra <= NgayNhan)
            {
                ModelState.AddModelError("", "Ngày trả phải lớn hơn ngày nhận");
                return View("Cart");
            }

            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            var item = new CartItem
            {
                ChiTietPhongId = ChiTietPhongId,
                HoTen = HoTen,
                SoDienThoai = SoDienThoai,
                NgayNhan = NgayNhan,
                NgayTra = NgayTra,
                NguoiLon = NguoiLon,
                TreEm = TreEm,
                TongTien = TongTien
            };

            cart.Add(item);

            HttpContext.Session.SetObject(CartSessionKey, cart);

            return RedirectToAction("Cart");
        }
        public IActionResult Cart()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            return View(cart);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey);

            if (cart == null || cart.Count == 0)
            {
                TempData["Message"] = "Giỏ hàng trống!";
                return RedirectToAction("Cart");
            }

            var username = User.Identity.Name;
            if (username == null)
            {
                return RedirectToAction("Login", "Account");
            }

            foreach (var item in cart)
            {
                var order = new Order
                {
                    UserName = username,
                    FullName = item.HoTen,
                    PhoneNumber = item.SoDienThoai,
                    ChiTietPhongId = item.ChiTietPhongId,
                    NgayNhan = item.NgayNhan,
                    NgayTra = item.NgayTra,
                    TongTien = item.TongTien,
                    TrangThai = TrangThaiDonHang.DangCho,
                    CreatedAt = DateTime.Now
                };

                _context.Orders.Add(order);
            }

            await _context.SaveChangesAsync();

            HttpContext.Session.Remove(CartSessionKey);

            return View("CheckoutSuccess");
        }
    }
}
