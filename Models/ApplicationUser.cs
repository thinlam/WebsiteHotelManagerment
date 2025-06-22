using Microsoft.AspNetCore.Identity;
using System;

namespace WebsiteHotelManagerment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? AvatarUrl { get; set; }
        public string? LastLoginIP { get; set; } // Cho phép null để tránh lỗi khi chưa có dữ liệu
    }
}
