namespace WebsiteHotelManagerment.Models
{
    public class NhanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }  // Ví dụ: Lễ tân, Kế toán, Quản lý
        public DateTime NgayVaoLam { get; set; }
    }

}
