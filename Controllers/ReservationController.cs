using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteHotelManagerment.Models;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;
using WebsiteRestaurant.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Web.Mvc;

namespace WebsiteHotelManagerment.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var datPhongs = _context.DatPhongs.Include(d => d.ChiTietPhong).ToList();
            return View(datPhongs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            LoadSelectLists(null);
            return View(new DatPhong
            {
                SoNguoiLon = 1,
                SoTreEm = 0,
                LoaiPhong = LoaiPhong.Don,
                TrangThai = DatPhong.TrangThaiDatPhong.ChoXacNhan,
                NgayNhan = DateTime.Today,
                NgayTra = DateTime.Today
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(DatPhong datPhong)
        {
            if (datPhong.NgayTra < datPhong.NgayNhan)
            {
                ModelState.AddModelError("NgayTra", "Ngày trả phòng phải bằng hoặc sau ngày nhận phòng.");
            }

            if (ModelState.IsValid)
            {
                datPhong.NgayDat = DateTime.Now;

                if (datPhong.ChiTietPhongId.HasValue)
                {
                    var phong = _context.ChiTietPhongs.Find(datPhong.ChiTietPhongId.Value);
                    if (phong == null)
                    {
                        ModelState.AddModelError("ChiTietPhongId", "Phòng chọn không tồn tại.");
                        LoadSelectLists(datPhong.ChiTietPhongId, datPhong.TrangThai, datPhong.LoaiPhong);
                        return View(datPhong);
                    }
                }

                _context.DatPhongs.Add(datPhong);
                await _context.SaveChangesAsync();

                // Gửi email xác nhận (bạn tự thay EmailService)
                string body = $@"
                <p>Kính chào <strong>{datPhong.HoTen}</strong>,</p>
                <p>Cảm ơn Quý khách đã tin tưởng và lựa chọn <strong>Khách Sạn THE GRAND MASTER</strong>.</p>
                <p>Chúng tôi xin xác nhận rằng Quý khách đã <strong>đặt phòng thành công</strong> với thông tin như sau:</p>
                <ul>
                    <li><strong>Ngày nhận phòng:</strong> {datPhong.NgayNhan:dd/MM/yyyy}</li>
                    <li><strong>Ngày trả phòng:</strong> {datPhong.NgayTra:dd/MM/yyyy}</li>
                    <li><strong>Số người lớn:</strong> {datPhong.SoNguoiLon} người</li>
                    <li><strong>Số trẻ em:</strong> {datPhong.SoTreEm} người</li>
                    <li><strong>Loại phòng:</strong> {GetEnumDisplayName(datPhong.LoaiPhong)}</li>
                </ul>
                <p>Chúng tôi rất hân hạnh được đón tiếp Quý khách.</p>
                <p>Trân trọng,<br/>Khách Sạn Ben</p>";

                var emailService = new EmailService();
                await emailService.SendEmailAsync(
                    datPhong.Email,
                    "Xác nhận đặt phòng tại Khách Sạn THE GRAND MASTER",
                    body
                );

                TempData["SuccessMessage"] = "Đặt phòng thành công! Email xác nhận đã được gửi.";
                return RedirectToAction("Add", "Reservation");
            }

            LoadSelectLists(datPhong.ChiTietPhongId, datPhong.TrangThai, datPhong.LoaiPhong);
            return View(datPhong);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var datPhong = _context.DatPhongs.Find(id);
            if (datPhong == null)
            {
                return NotFound();
            }

            LoadSelectLists(datPhong.ChiTietPhongId, datPhong.TrangThai, datPhong.LoaiPhong);
            return View(datPhong);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DatPhong datPhong)
        {
            if (datPhong.NgayTra < datPhong.NgayNhan)
            {
                ModelState.AddModelError("NgayTra", "Ngày trả phòng phải bằng hoặc sau ngày nhận phòng.");
            }

            if (ModelState.IsValid)
            {
                var existingDatPhong = _context.DatPhongs.Find(datPhong.Id);
                if (existingDatPhong == null)
                {
                    return NotFound();
                }

                existingDatPhong.HoTen = datPhong.HoTen;
                existingDatPhong.SoDienThoai = datPhong.SoDienThoai;
                existingDatPhong.NgayNhan = datPhong.NgayNhan;
                existingDatPhong.NgayTra = datPhong.NgayTra;
                existingDatPhong.SoNguoiLon = datPhong.SoNguoiLon;
                existingDatPhong.SoTreEm = datPhong.SoTreEm;
                existingDatPhong.LoaiPhong = datPhong.LoaiPhong;
                existingDatPhong.ChiTietPhongId = datPhong.ChiTietPhongId;
                existingDatPhong.TrangThai = datPhong.TrangThai;

                _context.SaveChanges();

                TempData["SuccessMessage"] = "Chỉnh sửa đặt phòng thành công!";
                return RedirectToAction("Index", "Reservation");
            }

            LoadSelectLists(datPhong.ChiTietPhongId, datPhong.TrangThai, datPhong.LoaiPhong);
            return View(datPhong);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var datPhong = _context.DatPhongs.Find(id);
            if (datPhong != null)
            {
                _context.DatPhongs.Remove(datPhong);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private string GetEnumDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())[0]
                            .GetCustomAttribute<DisplayAttribute>()?
                            .Name ?? enumValue.ToString();
        }

        private void LoadSelectLists(int? selectedChiTietPhongId = null, DatPhong.TrangThaiDatPhong? selectedTrangThai = null, LoaiPhong? selectedLoaiPhong = null)
        {
            ViewBag.ChiTietPhong = new SelectList(_context.ChiTietPhongs.ToList(), "Id", "TenPhong", selectedChiTietPhongId);

            ViewBag.TrangThai = new SelectList(
                Enum.GetValues(typeof(DatPhong.TrangThaiDatPhong))
                    .Cast<DatPhong.TrangThaiDatPhong>()
                    .Select(tt => new SelectListItem
                    {
                        Value = ((int)tt).ToString(),
                        Text = GetEnumDisplayName(tt)
                    }), "Value", "Text", ((int?)selectedTrangThai)?.ToString());

            ViewBag.LoaiPhong = new SelectList(
                Enum.GetValues(typeof(LoaiPhong))
                    .Cast<LoaiPhong>()
                    .Select(lp => new SelectListItem
                    {
                        Value = lp.ToString(),
                        Text = GetEnumDisplayName(lp)
                    }), "Value", "Text", selectedLoaiPhong?.ToString());
        }
        // 1. Check-in online
        [HttpPost]
        public ActionResult CheckInOnline(string bookingCode)
        {
            var booking = db.Reservations.FirstOrDefault(r => r.Code == bookingCode && !r.IsCheckedIn);
            if (booking == null) return View("Error");

            booking.IsCheckedIn = true;
            db.SaveChanges();
            return RedirectToAction("CheckInSuccess");
        }

        [HttpPost]
        public ActionResult ShareViaEmail(int id, string toEmail)
        {
            var booking = db.Reservations.Find(id);
            if (booking == null) return HttpNotFound();

            var body = $"Thông tin đặt phòng: {booking.RoomName}, từ {booking.CheckInDate}";
            var mail = new MailMessage("noreply@hotel.com", toEmail)
            {
                Subject = "Chia sẻ đặt phòng",
                Body = body
            };
            new SmtpClient().Send(mail);

            return RedirectToAction("Details", new { id = booking.Id });
        }

        public void SendReminder()
        {
            var tomorrow = DateTime.Now.AddDays(1).Date;
            var bookings = db.Reservations.Where(b => b.CheckInDate == tomorrow);
            foreach (var b in bookings)
            {
                var mail = new MailMessage("noreply@hotel.com", b.User.Email)
                {
                    Subject = "Nhắc nhở nhận phòng",
                    Body = $"Bạn có lịch nhận phòng vào ngày mai: {b.CheckInDate.ToShortDateString()}"
                };
                new SmtpClient().Send(mail);
            }
        }

        // 9. Đặt nhiều phòng cùng lúc
        [HttpPost]
        public ActionResult CreateMultiple(List<int> roomIds, DateTime checkIn, DateTime checkOut)
        {
            foreach (var roomId in roomIds)
            {
                var reservation = new Reservation
                {
                    RoomId = roomId,
                    CheckInDate = checkIn,
                    CheckOutDate = checkOut,
                    UserId = User.Identity.Name
                };
                db.Reservations.Add(reservation);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
}
