// Controllers/Admin/KhuyenMaiController.cs
using Microsoft.AspNetCore.Mvc;
using WebsiteHotelManagerment.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebsiteHotelManagerment.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class KhuyenMaiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhuyenMaiController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.KhuyenMais.OrderByDescending(km => km.NgayBatDau).ToList();
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(KhuyenMai model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.KhuyenMais.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var km = _context.KhuyenMais.Find(id);
            if (km == null) return NotFound();
            return View(km);
        }

        [HttpPost]
        public IActionResult Edit(KhuyenMai model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.KhuyenMais.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var km = _context.KhuyenMais.Find(id);
            if (km == null) return NotFound();

            _context.KhuyenMais.Remove(km);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
