using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Mặc định: User chat với Admin
        [Authorize(Roles = "User")]
        public async Task<IActionResult> ChatWithAdmin()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");

            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var adminUser = admins.FirstOrDefault();
            if (adminUser == null)
                return BadRequest("Không tìm thấy Admin để chat.");

            var messages = await _context.Messages
                .Where(m => (m.SenderId == currentUser.Id && m.ReceiverId == adminUser.Id)
                         || (m.SenderId == adminUser.Id && m.ReceiverId == currentUser.Id))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            ViewBag.AdminId = adminUser.Id;
            ViewBag.CurrentUserId = currentUser.Id;
            ViewBag.ChatWithUser = adminUser;

            return View(messages);
        }

        // Gửi tin nhắn user đến admin
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<JsonResult> SendMessageToAdmin(string content)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Json(new { success = false, message = "Unauthorized" });

            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var adminUser = admins.FirstOrDefault();
            if (adminUser == null)
                return Json(new { success = false, message = "Không tìm thấy Admin." });

            if (string.IsNullOrWhiteSpace(content))
                return Json(new { success = false, message = "Nội dung tin nhắn không được để trống." });

            var message = new Message
            {
                SenderId = user.Id,
                ReceiverId = adminUser.Id,
                Content = content,
                Timestamp = DateTime.Now,
                IsRead = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = new
                {
                    id = message.Id,
                    content = message.Content,
                    senderId = message.SenderId,
                    receiverId = message.ReceiverId,
                    timestamp = message.Timestamp.ToString("HH:mm dd/MM/yyyy")
                }
            });
        }


        // Chat chung user và người khác (vd admin hoặc user khác)
        public async Task<IActionResult> Index(string userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return RedirectToAction("Login", "Account");

            if (string.IsNullOrEmpty(userId))
                return BadRequest("User ID to chat with is required.");

            var messages = await _context.Messages
                .Where(m => (m.SenderId == currentUser.Id && m.ReceiverId == userId)
                         || (m.SenderId == userId && m.ReceiverId == currentUser.Id))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            ViewBag.ChatWithUserId = userId;
            ViewBag.CurrentUserId = currentUser.Id;

            return View(messages);
        }

        // Gửi tin nhắn mới từ user/admin trả về JSON (dùng AJAX)
        [HttpPost]
        public async Task<JsonResult> SendMessage(string receiverId, string content)
        {
            var sender = await _userManager.GetUserAsync(User);
            if (sender == null)
                return Json(new { success = false, message = "Unauthorized" });

            if (string.IsNullOrWhiteSpace(receiverId) || string.IsNullOrWhiteSpace(content))
                return Json(new { success = false, message = "Receiver ID and message content are required." });

            var message = new Message
            {
                SenderId = sender.Id,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.Now,
                IsRead = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = new
                {
                    id = message.Id,
                    content = message.Content,
                    senderId = message.SenderId,
                    receiverId = message.ReceiverId,
                    timestamp = message.Timestamp.ToString("HH:mm dd/MM/yyyy")
                }
            });
        }

        // Lấy tin nhắn giữa admin và user (dùng AJAX load chat)
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetMessagesWithUser(string userId)
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
                return Json(new { success = false, message = "Unauthorized" });

            if (string.IsNullOrWhiteSpace(userId))
                return Json(new { success = false, message = "UserId is required." });

            var messages = await _context.Messages
                .Where(m => (m.SenderId == admin.Id && m.ReceiverId == userId) ||
                            (m.SenderId == userId && m.ReceiverId == admin.Id))
                .OrderBy(m => m.Timestamp)
                .Select(m => new
                {
                    content = m.Content,
                    senderId = m.SenderId,
                    receiverId = m.ReceiverId,
                    timestamp = m.Timestamp.ToString("HH:mm dd/MM/yyyy")
                })
                .ToListAsync();

            return Json(messages);
        }

        // --- Danh sách người dùng đã chat với admin (chỉ admin xem được) ---
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserChats()
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
                return Unauthorized();

            var adminId = admin.Id;

            var userIds = await _context.Messages
                .Where(m => m.SenderId == adminId || m.ReceiverId == adminId)
                .Select(m => m.SenderId == adminId ? m.ReceiverId : m.SenderId)
                .Distinct()
                .ToListAsync();

            var users = await _context.Users
                .Where(u => userIds.Contains(u.Id))
                .ToListAsync();

            var messages = new List<Message>(); // hoặc lấy messages theo logic bạn muốn

            var model = Tuple.Create(users, messages);

            return View(model);
        }


        // --- Chat admin với user cụ thể ---
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminChatWithUser(string userId)
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
                return Unauthorized();

            if (string.IsNullOrEmpty(userId))
                return BadRequest("User ID is required.");

            var messages = await _context.Messages
                .Where(m => (m.SenderId == admin.Id && m.ReceiverId == userId)
                         || (m.SenderId == userId && m.ReceiverId == admin.Id))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            ViewBag.ChatWithUser = await _userManager.FindByIdAsync(userId);
            ViewBag.AdminId = admin.Id;

            return View(messages);
        }

        // --- Gửi tin nhắn từ admin đến user trả về JSON (dùng AJAX) ---
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> SendMessageToUser(string receiverId, string content)
        {
            var admin = await _userManager.GetUserAsync(User);
            if (admin == null)
                return Json(new { success = false, message = "Unauthorized" });

            if (string.IsNullOrWhiteSpace(receiverId) || string.IsNullOrWhiteSpace(content))
                return Json(new { success = false, message = "Receiver ID and message content are required." });

            var message = new Message
            {
                SenderId = admin.Id,
                ReceiverId = receiverId,
                Content = content,
                Timestamp = DateTime.Now,
                IsRead = false
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = new
                {
                    id = message.Id,
                    content = message.Content,
                    senderId = message.SenderId,
                    receiverId = message.ReceiverId,
                    timestamp = message.Timestamp.ToString("HH:mm dd/MM/yyyy")
                }
            });
        }

        [Authorize] // Hoặc không đặt Roles nếu muốn mọi user đều dùng được
        public async Task<PartialViewResult> ChatWidget(string userId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
                return PartialView("_ChatWidget", new List<Message>());

            if (string.IsNullOrEmpty(userId))
                return PartialView("_ChatWidget", new List<Message>());

            var messages = await _context.Messages
                .Where(m => (m.SenderId == currentUser.Id && m.ReceiverId == userId)
                         || (m.SenderId == userId && m.ReceiverId == currentUser.Id))
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            ViewBag.ChatWithUser = await _userManager.FindByIdAsync(userId);
            ViewBag.AdminId = currentUser.Id; // Hoặc tùy bạn đặt biến này để check tin nhắn gửi từ ai

            return PartialView("_ChatWidget", messages);
        }
    }
}
