using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteHotelManagerment.Models
{
    public class DatPhong
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Ngày nhận phòng không được để trống")]
        [DataType(DataType.Date)]
        public DateTime NgayNhan { get; set; }

        [Required(ErrorMessage = "Ngày trả phòng không được để trống")]
        [DataType(DataType.Date)]
        public DateTime NgayTra { get; set; }

        [Range(1, 20, ErrorMessage = "Số người lớn phải lớn hơn 0")]
        public int SoNguoiLon { get; set; } = 1;

        [Range(0, 10, ErrorMessage = "Số trẻ em không hợp lệ")]
        public int SoTreEm { get; set; } = 0;
        public int? ChiTietPhongId { get; set; }

        [ForeignKey(nameof(ChiTietPhongId))]
        public ChiTietPhong? ChiTietPhong { get; set; }

        public DateTime NgayDat { get; set; } = DateTime.Now;

        public TrangThaiDatPhong TrangThai { get; set; } = TrangThaiDatPhong.ChoXacNhan;

        [Required(ErrorMessage = "Vui lòng chọn loại phòng")]
        public LoaiPhong? LoaiPhong { get; set; }

        // Liên kết thanh toán nếu có
        public ThanhToan? ThanhToan { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }
        public enum TrangThaiDatPhong
        {
            [Display(Name = "Chờ xác nhận")]
            ChoXacNhan = 0,

            [Display(Name = "Đã xác nhận")]
            DaXacNhan = 1,

            [Display(Name = "Đã hủy")]
            DaHuy = 2
        }
    }
}
