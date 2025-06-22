using System.ComponentModel.DataAnnotations;

namespace WebsiteHotelManagerment.Models
{
    public enum LoaiPhong
    {
        [Display(Name = "Đơn")]
        Don,

        [Display(Name = "Đôi")]
        Doi,

        [Display(Name = "Vip")]
        Vip
    }
}
