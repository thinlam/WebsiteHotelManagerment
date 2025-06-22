using Microsoft.AspNetCore.Mvc;
using WebsiteHotelManagerment.Models;

public class NhanVienController : Controller
{
    private readonly ApplicationDbContext _context;

    public NhanVienController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var list = _context.NhanViens.ToList();
        return View(list);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(NhanVien nv)
    {
        if (ModelState.IsValid)
        {
            _context.NhanViens.Add(nv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(nv);
    }

    public IActionResult Edit(int id)
    {
        var nv = _context.NhanViens.Find(id);
        return View(nv);
    }

    [HttpPost]
    public IActionResult Edit(NhanVien nv)
    {
        if (ModelState.IsValid)
        {
            _context.NhanViens.Update(nv);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(nv);
    }

    public IActionResult Delete(int id)
    {
        var nv = _context.NhanViens.Find(id);
        return View(nv);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var nv = _context.NhanViens.Find(id);
        _context.NhanViens.Remove(nv);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
