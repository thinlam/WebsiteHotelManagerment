using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteHotelManagerment.Models
{
    public enum TrangThaiDonHang
    {
        [Display(Name = "Đang chờ")]
        DangCho = 0,

        [Display(Name = "Đang xử lý")]
        DangXuLy = 1,

        [Display(Name = "Đã thành công")]
        DaThanhCong = 2
    }
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime NgayNhan { get; set; }

        [Required]
        public DateTime NgayTra { get; set; }

        [Required]
        public int NguoiLon { get; set; }

        [Required]
        public int TreEm { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TongTien { get; set; }

        public TrangThaiDonHang TrangThai { get; set; } = TrangThaiDonHang.DangCho;
        public DateTime? CreatedAt { get; set; }

        // Liên kết với phòng đã chọn
        public int ChiTietPhongId { get; set; }

        [ForeignKey("ChiTietPhongId")]
        public ChiTietPhong ChiTietPhong { get; set; }
        public string UserName { get; set; }
    }
}
