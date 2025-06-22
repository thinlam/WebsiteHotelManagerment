using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteHotelManagerment.Models
{
    public class ThanhToan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ChiTietPhongId { get; set; }
        [ForeignKey(nameof(ChiTietPhongId))]
        public ChiTietPhong ChiTietPhong { get; set; }
        [Required]
        public decimal SoTien { get; set; }
        public DateTime NgayThanhToan { get; set; } = DateTime.Now;
        public string HinhThucThanhToan { get; set; }  // Tiền mặt, thẻ, chuyển khoản...
        public bool DaThanhToan { get; set; } = false;
    }
}
