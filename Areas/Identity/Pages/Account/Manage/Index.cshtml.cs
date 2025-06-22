using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using WebsiteHotelManagerment.Models;

namespace WebsiteRestaurant.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public IndexModel(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Display(Name = "Họ và tên")]
            public string FullName { get; set; }

            [Display(Name = "Giới tính")]
            public string Gender { get; set; }

            [Display(Name = "Ngày sinh")]
            public DateTime? DateOfBirth { get; set; }

            [Display(Name = "Địa chỉ")]
            public string Address { get; set; }

            public string? AvatarUrl { get; set; }

            [Display(Name = "Tải ảnh đại diện")]
            public IFormFile? AvatarFile { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                StatusMessage = "Không tìm thấy người dùng.";
                return NotFound();
            }

            Input = new InputModel
            {
                FullName = user.FullName,
                Gender = user.Gender,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                AvatarUrl = user.AvatarUrl
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                StatusMessage = "Dữ liệu không hợp lệ.";
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                StatusMessage = "Không tìm thấy người dùng.";
                return NotFound();
            }

            user.FullName = Input.FullName;
            user.Gender = Input.Gender;
            user.DateOfBirth = Input.DateOfBirth;
            user.Address = Input.Address;

            if (Input.AvatarFile != null)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "images");
                var uniqueFileName = $"{Guid.NewGuid()}_{Input.AvatarFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                try
                {
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Input.AvatarFile.CopyToAsync(stream);
                    }

                    if (!string.IsNullOrEmpty(user.AvatarUrl))
                    {
                        var oldFilePath = Path.Combine(_env.WebRootPath, user.AvatarUrl.TrimStart('/'));
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    user.AvatarUrl = $"/images/{uniqueFileName}";
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Lỗi khi lưu ảnh: {ex.Message}");
                    return Page();
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                StatusMessage = "Cập nhật thông tin thất bại.";
                return Page();
            }

            StatusMessage = "Lưu thông tin thành công.";
            return RedirectToPage();
        }
    }
}
