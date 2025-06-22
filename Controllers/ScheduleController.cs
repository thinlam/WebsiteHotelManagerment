using Microsoft.AspNetCore.Mvc;
using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Weekly()
        {
            var shifts = _context.WorkShifts
                .Where(s => s.ShiftDate >= DateTime.Now.Date &&
                            s.ShiftDate <= DateTime.Now.Date.AddDays(7))
                .OrderBy(s => s.ShiftDate)
                .ToList();

            return View(shifts);
        }
    }
}
