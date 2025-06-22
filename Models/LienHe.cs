using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteHotelManagerment.Models
{
    public class LienHe
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [Display(Name = "Họ và tên")]
        [StringLength(100)]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Ngày gửi")]
        public DateTime NgayGui { get; set; } = DateTime.Now;
    }
}
