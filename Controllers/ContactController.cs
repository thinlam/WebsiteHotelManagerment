using Microsoft.AspNetCore.Mvc;
using WebsiteHotelManagerment.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebsiteHotelManagerment.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        // GET: /Contact
        public IActionResult Index()
        {
            var danhSachLienHe = _context.LienHes.OrderByDescending(x => x.NgayGui).ToList();
            return View(danhSachLienHe);
        }
        // GET: /Contact/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Contact/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                lienHe.NgayGui = DateTime.Now;
                _context.LienHes.Add(lienHe);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Gửi liên hệ thành công!";
                return RedirectToAction("Add", "Contact");
            }

            return View(lienHe);
        }
        [Authorize(Roles = "Admin")]
        // GET: /Contact/Edit/5
        public IActionResult Edit(int id)
        {
            var lienHe = _context.LienHes.Find(id);
            if (lienHe == null)
            {
                return NotFound();
            }

            return View(lienHe);
        }
        [Authorize(Roles = "Admin")]
        // POST: /Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(LienHe lienHe)
        {
            if (ModelState.IsValid)
            {
                _context.LienHes.Update(lienHe);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Cập nhật liên hệ thành công!";
                return RedirectToAction("Index", "Contact");
            }

            return View(lienHe);
        }
        [Authorize(Roles = "Admin")]
        // GET: /Contact/Delete/5
        public IActionResult Delete(int id)
        {
            var lienHe = _context.LienHes.Find(id);
            if (lienHe == null)
            {
                return NotFound();
            }

            _context.LienHes.Remove(lienHe);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Xóa liên hệ thành công!";
            return RedirectToAction("Index", "Contact");
        }
    }
}
