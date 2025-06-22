using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteHotelManagerment.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } // Foreign Key

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } // Navigation Property

        [Required]
        [StringLength(1000)]
        public string Content { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? ImagePath { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string? AdminReply { get; set; }

        [StringLength(100)]
        public string? ReviewType { get; set; } // "Dịch vụ" hoặc "Đặt phòng"
    }
}
