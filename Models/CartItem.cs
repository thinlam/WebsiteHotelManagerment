namespace WebsiteHotelManagerment.Models
{
    public class CartItem
    {
        public int ChiTietPhongId { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public int NguoiLon { get; set; }
        public int TreEm { get; set; }
        public decimal TongTien { get; set; }
    }
}
