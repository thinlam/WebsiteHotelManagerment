// Models/KhuyenMai.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteHotelManagerment.Models
{
    public class KhuyenMai
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tên khuyến mãi")]
        public string Tieude { get; set; }

        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        [Display(Name = "Ngày bắt đầu")]
        [DataType(DataType.Date)]
        public DateTime NgayBatDau { get; set; }

        [Display(Name = "Ngày kết thúc")]
        [DataType(DataType.Date)]
        public DateTime NgayKetThuc { get; set; }

        [Display(Name = "Phần trăm giảm (%)")]
        [Range(0, 100)]
        public int PhanTramGiam { get; set; }

        [Display(Name = "Áp dụng cho loại phòng")]
        public string? ApDungChoLoaiPhong { get; set; } // VD: "Don", "Doi", "Vip", "TatCa"
    }
}
