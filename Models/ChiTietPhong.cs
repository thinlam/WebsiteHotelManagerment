using System.ComponentModel.DataAnnotations;

namespace WebsiteHotelManagerment.Models
{
    public class ChiTietPhong
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên phòng không được để trống")]
        public string TenPhong { get; set; }
        public string MoTa { get; set; }
        public string TienNghi { get; set; }

        [Range(1, 100, ErrorMessage = "Số người lớn phải từ 1 đến 100")]
        public int SoNguoiLon { get; set; }

        [Range(0, 100, ErrorMessage = "Số trẻ em phải từ 0 đến 100")]
        public int SoTreEm { get; set; }

        [Range(1, 1000, ErrorMessage = "Diện tích phải lớn hơn 0")]
        public int DienTich { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        public decimal GiaMoiDem { get; set; }
        public string? TenFileAnh { get; set; }
        public string? TieuDeAnh { get; set; }
        [Required(ErrorMessage = "Phân loại phòng không được để trống")]
        public LoaiPhong? PhanLoai { get; set; }
        public ICollection<ThanhToan>? ThanhToans { get; set; }
        public virtual ICollection<DatPhong> DatPhongs { get; set; } = new List<DatPhong>();
        public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    }
}
