using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public ReviewController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _userManager = userManager;
            _environment = environment;
        }

        [Authorize]
        public async Task<IActionResult> Create()
        {
            var user = await _userManager.GetUserAsync(User);
            var allReviews = _context.Reviews
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            var hasReviewed = _context.Reviews.Any(r => r.UserId == user.Id);
            ViewData["AllReviews"] = allReviews;
            ViewData["HasReviewed"] = hasReviewed;

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Review model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var hasReviewed = _context.Reviews.Any(r => r.UserId == user.Id);
            if (hasReviewed)
            {
                TempData["Error"] = "Bạn đã đánh giá rồi. Mỗi tài khoản chỉ được đánh giá một lần.";
                return RedirectToAction("Create");
            }

            model.UserId = user.Id;
            model.CreatedAt = DateTime.Now;
            model.ReviewType = Request.Form["ReviewType"];

            if (model.Rating >= 4)
            {
                model.AdminReply = "Cảm ơn bạn đã đánh giá tích cực. Chúng tôi rất vui khi nhận được phản hồi từ bạn!";
            }

            // Xử lý hình ảnh nếu có
            var imageFile = Request.Form.Files["image"];
            if (imageFile != null && imageFile.Length > 0)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads/reviews");
                Directory.CreateDirectory(uploads);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.ImagePath = "/uploads/reviews/" + fileName;
            }

            _context.Reviews.Add(model);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Cảm ơn bạn đã gửi đánh giá!";
            return RedirectToAction("Create");
        }

        public IActionResult Index()
        {
            var reviews = _context.Reviews
                .Include(r => r.User)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return View(reviews);
        }

        [Authorize]
        public async Task<IActionResult> MyReviews()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Redirect("/Identity/Account/Login");

            var reviews = _context.Reviews
                .Where(r => r.UserId == user.Id)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

            return View(reviews);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditReview(int Id, int Rating, string Content)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Redirect("/Identity/Account/Login");

            var review = _context.Reviews.FirstOrDefault(r => r.Id == Id && r.UserId == user.Id);
            if (review == null) return NotFound();

            review.Rating = Rating;
            review.Content = Content;

            var newImage = Request.Form.Files["NewImage"];
            if (newImage != null && newImage.Length > 0)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads/reviews");
                Directory.CreateDirectory(uploads);
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(newImage.FileName);
                var filePath = Path.Combine(uploads, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await newImage.CopyToAsync(stream);
                }

                review.ImagePath = "/uploads/reviews/" + fileName;
            }

            // Cập nhật phản hồi nếu đủ điểm
            if (review.Rating >= 4 && string.IsNullOrEmpty(review.AdminReply))
            {
                review.AdminReply = "Cảm ơn bạn đã đánh giá tích cực. Chúng tôi rất vui khi nhận được phản hồi từ bạn!";
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("MyReviews");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Reply(int id, string reply)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound();

            review.AdminReply = reply;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
