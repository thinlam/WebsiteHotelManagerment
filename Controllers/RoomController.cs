using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebsiteHotelManagerment.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace WebsiteHotelManagerment.Controllers
{
    public class RoomController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly string _imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/room");

        public RoomController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lấy danh sách enum LoaiPhong hiển thị có dấu (dùng DisplayAttribute)
        private List<SelectListItem> GetLoaiPhongSelectList()
        {
            var values = Enum.GetValues(typeof(LoaiPhong)).Cast<LoaiPhong>();
            return values.Select(v => new SelectListItem
            {
                Text = GetEnumDisplayName(v),
                Value = v.ToString()
            }).ToList();
        }

        private string GetEnumDisplayName(Enum enumValue)
        {
            var memInfo = enumValue.GetType().GetMember(enumValue.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((DisplayAttribute)attrs[0]).Name;
                }
            }
            return enumValue.ToString();
        }

        // Trang danh sách, filter keyword, loại phòng và mức giá, phân trang
        public IActionResult Index(string keyword, List<string> roomTypes, List<int> prices, int page = 1)
        {
            int pageSize = 12;
            var query = _context.ChiTietPhongs.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(r => r.TenPhong.Contains(keyword));
            }

            var list = query.ToList();

            if (roomTypes != null && roomTypes.Count > 0)
            {
                list = list.Where(r => roomTypes.Contains(r.PhanLoai.ToString())).ToList();
            }

            if (prices != null && prices.Count > 0)
            {
                list = list.Where(r => prices.Any(p => r.GiaMoiDem <= p)).ToList();
            }

            int totalItems = list.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            page = Math.Clamp(page, 1, totalPages);

            var pagedList = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Truyền dữ liệu cho view
            ViewBag.LoaiPhongList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Phòng đơn", Value = "Don" },
        new SelectListItem { Text = "Phòng đôi", Value = "Doi" },
        new SelectListItem { Text = "Phòng VIP", Value = "Vip" }
    };
            ViewBag.SelectedRoomTypes = roomTypes ?? new List<string>();
            ViewBag.SelectedPrices = prices ?? new List<int>();
            ViewBag.Keyword = keyword;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedList);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            ViewBag.LoaiPhongList = GetLoaiPhongSelectList();
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(ChiTietPhong model, IFormFile fileAnh)
        {
            if (fileAnh == null || fileAnh.Length == 0)
                ModelState.AddModelError("fileAnh", "Bạn phải chọn ảnh phòng.");

            if (!ModelState.IsValid)
            {
                ViewBag.LoaiPhongList = GetLoaiPhongSelectList();
                return View(model);
            }

            if (!Directory.Exists(_imageFolder))
                Directory.CreateDirectory(_imageFolder);

            var fileName = Path.GetFileName(fileAnh.FileName);
            var path = Path.Combine(_imageFolder, fileName);

            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    fileAnh.CopyTo(stream);
                }
                model.TenFileAnh = fileName;
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi lưu ảnh: " + ex.Message);
                ViewBag.LoaiPhongList = GetLoaiPhongSelectList();
                return View(model);
            }

            _context.ChiTietPhongs.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var room = _context.ChiTietPhongs.FirstOrDefault(p => p.Id == id);
            if (room == null) return NotFound();
            return View(room);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var room = _context.ChiTietPhongs.FirstOrDefault(p => p.Id == id);
            if (room == null) return NotFound();
            ViewBag.LoaiPhongList = GetLoaiPhongSelectList();
            return View(room);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(ChiTietPhong model, IFormFile fileAnh)
        {

            ModelState.Remove("fileAnh");
            var existing = _context.ChiTietPhongs.FirstOrDefault(p => p.Id == model.Id);
            if (existing == null) return NotFound();

            // Nếu có lỗi validate (nhưng KHÔNG phải do thiếu ảnh), thì render lại view
            if (!ModelState.IsValid)
            {
                ViewBag.LoaiPhongList = GetLoaiPhongSelectList();
                return View(model);
            }

            // Cập nhật thông tin
            existing.TenPhong = model.TenPhong;
            existing.MoTa = model.MoTa;
            existing.TienNghi = model.TienNghi;
            existing.SoNguoiLon = model.SoNguoiLon;
            existing.SoTreEm = model.SoTreEm;
            existing.DienTich = model.DienTich;
            existing.GiaMoiDem = model.GiaMoiDem;
            existing.TieuDeAnh = model.TieuDeAnh;
            existing.PhanLoai = model.PhanLoai;

            // Nếu người dùng có chọn ảnh mới thì lưu ảnh
            if (fileAnh != null && fileAnh.Length > 0)
            {
                var fileName = Path.GetFileName(fileAnh.FileName);
                var path = Path.Combine(_imageFolder, fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    fileAnh.CopyTo(stream);
                }

                existing.TenFileAnh = fileName;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var room = _context.ChiTietPhongs.FirstOrDefault(p => p.Id == id);
            if (room == null) return NotFound();
            return View(room);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var room = _context.ChiTietPhongs.FirstOrDefault(p => p.Id == id);
            if (room == null) return NotFound();

            if (!string.IsNullOrEmpty(room.TenFileAnh))
            {
                var imagePath = Path.Combine(_imageFolder, room.TenFileAnh);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
            }

            _context.ChiTietPhongs.Remove(room);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
