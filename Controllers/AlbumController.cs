using Microsoft.AspNetCore.Mvc;

namespace WebsiteHotelManagerment.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
