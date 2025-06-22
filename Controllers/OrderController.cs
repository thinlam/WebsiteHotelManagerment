using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteHotelManagerment.Models;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteHotelManagerment.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        // Người dùng xem lịch sử đơn của mình
        public async Task<IActionResult> History()
        {
            var username = User.Identity.Name;
            var orders = await _context.Orders
                .Include(o => o.ChiTietPhong)
                .Where(o => o.UserName == username)
                .OrderByDescending(o => o.NgayNhan)
                .ToListAsync();

            return View(orders);
        }

        // Admin xem toàn bộ đơn hàng
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.ChiTietPhong)
                .OrderByDescending(o => o.NgayNhan)
                .ToListAsync();

            return View(orders);
        }

        // Admin cập nhật trạng thái đơn hàng
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, TrangThaiDonHang trangThai)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
                return NotFound();

            order.TrangThai = trangThai;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}
