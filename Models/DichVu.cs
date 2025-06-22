using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteHotelManagerment.Models
{
    public class DichVu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TenDichVu { get; set; }

        public string MoTa { get; set; }

        [DataType(DataType.Currency)]
        public decimal Gia { get; set; }
    }
}
