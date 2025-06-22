using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsiteHotelManagerment.Models
{
    public class Phong
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoaiPhong { get; set; }

        public string MoTa { get; set; }

        public ICollection<ChiTietPhong> ChiTietPhongs { get; set; }
    }
}
