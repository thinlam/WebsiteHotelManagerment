using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebsiteHotelManagerment.Models;

public class EditProfileModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;

    public EditProfileModel(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [BindProperty]
    [Required]
    public string FullName { get; set; }

    [BindProperty]
    public string AvatarUrl { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("Không tìm thấy người dùng.");
        }

        FullName = user.FullName;
        AvatarUrl = user.AvatarUrl;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("Không tìm thấy người dùng.");
        }

        user.FullName = FullName;
        user.AvatarUrl = AvatarUrl;

        await _userManager.UpdateAsync(user);

        TempData["Success"] = "Cập nhật thành công!";
        return RedirectToPage(); // reload
    }
}
