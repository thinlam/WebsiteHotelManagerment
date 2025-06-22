using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteHotelManagerment.Models;

namespace WebsiteHotelManagerment.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ChiTietPhong> ChiTietPhongs { get; set; }
        public DbSet<DatPhong> DatPhongs { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<ThanhToan> ThanhToans { get; set; }
        public DbSet<LienHe> LienHes { get; set; }
        public DbSet<DichVu> DichVus { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Cấu hình khóa ngoại cho Message
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<ChiTietPhong>().HasData(
                new ChiTietPhong { Id = 1, TenPhong = "Phòng Đẹp VIP", TenFileAnh = "don1.png", TieuDeAnh = "Ảnh phòng đơn 1", SoNguoiLon = 1, SoTreEm = 0, DienTich = 20, GiaMoiDem = 500000, MoTa = "Phòng đơn nhỏ gọn", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 2, TenPhong = "Phòng Đôi 1", TenFileAnh = "doi1.png", TieuDeAnh = "Ảnh phòng đôi 1", SoNguoiLon = 2, SoTreEm = 1, DienTich = 28, GiaMoiDem = 700000, MoTa = "Phòng đôi thoáng mát", TienNghi = "Wifi, Điều hòa", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 3, TenPhong = "Phòng VIP 1", TenFileAnh = "vip1.png", TieuDeAnh = "Ảnh phòng VIP 1", SoNguoiLon = 3, SoTreEm = 1, DienTich = 35, GiaMoiDem = 1200000, MoTa = "Phòng VIP tiện nghi cao cấp", TienNghi = "Wifi, Điều hòa, Bồn tắm", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 4, TenPhong = "Phòng Đơn 2", TenFileAnh = "don2.png", TieuDeAnh = "Ảnh phòng đơn 2", SoNguoiLon = 1, SoTreEm = 0, DienTich = 22, GiaMoiDem = 550000, MoTa = "Phòng đơn hiện đại", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 5, TenPhong = "Phòng Đôi 2", TenFileAnh = "doi2.png", TieuDeAnh = "Ảnh phòng đôi 2", SoNguoiLon = 2, SoTreEm = 1, DienTich = 30, GiaMoiDem = 750000, MoTa = "Phòng đôi ấm cúng", TienNghi = "Wifi, Điều hòa, TV", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 6, TenPhong = "Phòng VIP 2", TenFileAnh = "vip2.png", TieuDeAnh = "Ảnh phòng VIP 2", SoNguoiLon = 4, SoTreEm = 2, DienTich = 40, GiaMoiDem = 1400000, MoTa = "Phòng VIP rộng rãi", TienNghi = "Wifi, Điều hòa, TV, Bồn tắm", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 7, TenPhong = "Phòng Đơn 3", TenFileAnh = "don3.png", TieuDeAnh = "Ảnh phòng đơn 3", SoNguoiLon = 1, SoTreEm = 1, DienTich = 23, GiaMoiDem = 520000, MoTa = "Phòng đơn giá rẻ", TienNghi = "Wifi", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 8, TenPhong = "Phòng Đôi 3", TenFileAnh = "doi3.png", TieuDeAnh = "Ảnh phòng đôi 3", SoNguoiLon = 2, SoTreEm = 0, DienTich = 29, GiaMoiDem = 730000, MoTa = "Phòng đôi đơn giản", TienNghi = "Wifi, Điều hòa", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 9, TenPhong = "Phòng VIP 3", TenFileAnh = "vip3.png", TieuDeAnh = "Ảnh phòng VIP 3", SoNguoiLon = 3, SoTreEm = 2, DienTich = 38, GiaMoiDem = 1350000, MoTa = "Phòng VIP sang trọng", TienNghi = "Wifi, Điều hòa, Bồn tắm, TV", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 10, TenPhong = "Phòng Đơn 4", TenFileAnh = "don4.png", TieuDeAnh = "Ảnh phòng đơn 4", SoNguoiLon = 1, SoTreEm = 0, DienTich = 21, GiaMoiDem = 510000, MoTa = "Phòng đơn yên tĩnh", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Don },

                // 20 bản còn lại tương tự
                new ChiTietPhong { Id = 11, TenPhong = "Phòng Đôi 4", TenFileAnh = "doi4.png", TieuDeAnh = "Ảnh phòng đôi 4", SoNguoiLon = 2, SoTreEm = 2, DienTich = 32, GiaMoiDem = 780000, MoTa = "Phòng đôi view đẹp", TienNghi = "Wifi, TV, Điều hòa", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 12, TenPhong = "Phòng VIP 4", TenFileAnh = "vip4.png", TieuDeAnh = "Ảnh phòng VIP 4", SoNguoiLon = 4, SoTreEm = 2, DienTich = 42, GiaMoiDem = 1450000, MoTa = "Phòng VIP tiện nghi đầy đủ", TienNghi = "Wifi, TV, Điều hòa, Bồn tắm", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 13, TenPhong = "Phòng Đơn 5", TenFileAnh = "don5.png", TieuDeAnh = "Ảnh phòng đơn 5", SoNguoiLon = 1, SoTreEm = 0, DienTich = 20, GiaMoiDem = 490000, MoTa = "Phòng đơn nhỏ", TienNghi = "Wifi", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 14, TenPhong = "Phòng Đôi 5", TenFileAnh = "doi5.png", TieuDeAnh = "Ảnh phòng đôi 5", SoNguoiLon = 2, SoTreEm = 1, DienTich = 27, GiaMoiDem = 710000, MoTa = "Phòng đôi sạch sẽ", TienNghi = "Wifi, Điều hòa", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 15, TenPhong = "Phòng VIP 5", TenFileAnh = "vip5.png", TieuDeAnh = "Ảnh phòng VIP 5", SoNguoiLon = 3, SoTreEm = 2, DienTich = 36, GiaMoiDem = 1300000, MoTa = "Phòng VIP thoáng mát", TienNghi = "Wifi, Điều hòa, TV", PhanLoai = LoaiPhong.Vip },

                // Tiếp tục tạo cho đến Id = 30
                new ChiTietPhong { Id = 16, TenPhong = "Phòng Đơn 6", TenFileAnh = "don6.png", TieuDeAnh = "Ảnh phòng đơn 6", SoNguoiLon = 1, SoTreEm = 1, DienTich = 24, GiaMoiDem = 530000, MoTa = "Phòng đơn tiện nghi", TienNghi = "Wifi, Điều hòa", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 17, TenPhong = "Phòng Đôi 6", TenFileAnh = "doi6.png", TieuDeAnh = "Ảnh phòng đôi 6", SoNguoiLon = 2, SoTreEm = 2, DienTich = 31, GiaMoiDem = 760000, MoTa = "Phòng đôi hiện đại", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 18, TenPhong = "Phòng VIP 6", TenFileAnh = "vip6.png", TieuDeAnh = "Ảnh phòng VIP 6", SoNguoiLon = 4, SoTreEm = 1, DienTich = 43, GiaMoiDem = 1500000, MoTa = "Phòng VIP cao cấp", TienNghi = "Wifi, Điều hòa, TV, Bồn tắm", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 19, TenPhong = "Phòng Đơn 7", TenFileAnh = "don7.png", TieuDeAnh = "Ảnh phòng đơn 7", SoNguoiLon = 1, SoTreEm = 0, DienTich = 20, GiaMoiDem = 500000, MoTa = "Phòng đơn yên bình", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 20, TenPhong = "Phòng Đôi 7", TenFileAnh = "doi7.png", TieuDeAnh = "Ảnh phòng đôi 7", SoNguoiLon = 2, SoTreEm = 1, DienTich = 29, GiaMoiDem = 740000, MoTa = "Phòng đôi sạch sẽ", TienNghi = "Wifi, Điều hòa", PhanLoai = LoaiPhong.Doi },

                new ChiTietPhong { Id = 21, TenPhong = "Phòng VIP 7", TenFileAnh = "vip7.png", TieuDeAnh = "Ảnh phòng VIP 7", SoNguoiLon = 3, SoTreEm = 2, DienTich = 39, GiaMoiDem = 1380000, MoTa = "Phòng VIP hiện đại", TienNghi = "Wifi, Điều hòa, TV", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 22, TenPhong = "Phòng Đơn 8", TenFileAnh = "don8.png", TieuDeAnh = "Ảnh phòng đơn 8", SoNguoiLon = 1, SoTreEm = 1, DienTich = 22, GiaMoiDem = 520000, MoTa = "Phòng đơn tiết kiệm", TienNghi = "Wifi", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 23, TenPhong = "Phòng Đôi 8", TenFileAnh = "doi8.png", TieuDeAnh = "Ảnh phòng đôi 8", SoNguoiLon = 2, SoTreEm = 2, DienTich = 33, GiaMoiDem = 790000, MoTa = "Phòng đôi thoải mái", TienNghi = "Wifi, TV, Điều hòa", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 24, TenPhong = "Phòng VIP 8", TenFileAnh = "vip8.png", TieuDeAnh = "Ảnh phòng VIP 8", SoNguoiLon = 4, SoTreEm = 2, DienTich = 45, GiaMoiDem = 1550000, MoTa = "Phòng VIP đẳng cấp", TienNghi = "Wifi, TV, Điều hòa, Bồn tắm", PhanLoai = LoaiPhong.Vip },

                // Các phòng từ 25–30 (tuỳ chỉnh tương tự)
                new ChiTietPhong { Id = 25, TenPhong = "Phòng Đơn 9", TenFileAnh = "don9.png", TieuDeAnh = "Ảnh phòng đơn 9", SoNguoiLon = 1, SoTreEm = 0, DienTich = 21, GiaMoiDem = 500000, MoTa = "Phòng đơn thư giãn", TienNghi = "Wifi", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 26, TenPhong = "Phòng Đôi 9", TenFileAnh = "doi9.png", TieuDeAnh = "Ảnh phòng đôi 9", SoNguoiLon = 2, SoTreEm = 1, DienTich = 30, GiaMoiDem = 750000, MoTa = "Phòng đôi tiện nghi", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 27, TenPhong = "Phòng VIP 9", TenFileAnh = "vip9.png", TieuDeAnh = "Ảnh phòng VIP 9", SoNguoiLon = 3, SoTreEm = 2, DienTich = 41, GiaMoiDem = 1450000, MoTa = "Phòng VIP ấm cúng", TienNghi = "Wifi, Điều hòa, Bồn tắm", PhanLoai = LoaiPhong.Vip },
                new ChiTietPhong { Id = 28, TenPhong = "Phòng Đơn 10", TenFileAnh = "don10.png", TieuDeAnh = "Ảnh phòng đơn 10", SoNguoiLon = 1, SoTreEm = 0, DienTich = 23, GiaMoiDem = 510000, MoTa = "Phòng đơn tiện lợi", TienNghi = "Wifi, TV", PhanLoai = LoaiPhong.Don },
                new ChiTietPhong { Id = 29, TenPhong = "Phòng Đôi 10", TenFileAnh = "doi10.png", TieuDeAnh = "Ảnh phòng đôi 10", SoNguoiLon = 2, SoTreEm = 1, DienTich = 28, GiaMoiDem = 720000, MoTa = "Phòng đôi phổ thông", TienNghi = "Wifi, Điều hòa", PhanLoai = LoaiPhong.Doi },
                new ChiTietPhong { Id = 30, TenPhong = "Phòng VIP 10", TenFileAnh = "vip10.png", TieuDeAnh = "Ảnh phòng VIP 10", SoNguoiLon = 4, SoTreEm = 2, DienTich = 44, GiaMoiDem = 1600000, MoTa = "Phòng VIP rộng và đẹp", TienNghi = "Wifi, TV, Bồn tắm", PhanLoai = LoaiPhong.Vip }
            );

            modelBuilder.Entity<LienHe>().HasData(
    new LienHe { Id = 1, HoTen = "Nguyễn Văn A", Email = "a@gmail.com", NoiDung = "Tôi cần hỗ trợ đặt phòng.", NgayGui = DateTime.Now },
    new LienHe { Id = 2, HoTen = "Trần Thị B", Email = "b@gmail.com", NoiDung = "Khách sạn có hồ bơi không?", NgayGui = DateTime.Now },
    new LienHe { Id = 3, HoTen = "Lê Văn C", Email = "c@gmail.com", NoiDung = "Phòng đơn giá bao nhiêu?", NgayGui = DateTime.Now },
    new LienHe { Id = 4, HoTen = "Phạm Thị D", Email = "d@gmail.com", NoiDung = "Check-in lúc mấy giờ?", NgayGui = DateTime.Now },
    new LienHe { Id = 5, HoTen = "Đỗ Văn E", Email = "e@gmail.com", NoiDung = "Tôi muốn đổi lịch nhận phòng.", NgayGui = DateTime.Now },
    new LienHe { Id = 6, HoTen = "Bùi Thị F", Email = "f@gmail.com", NoiDung = "Có phục vụ ăn sáng không?", NgayGui = DateTime.Now },
    new LienHe { Id = 7, HoTen = "Ngô Văn G", Email = "g@gmail.com", NoiDung = "Tôi muốn huỷ phòng đã đặt.", NgayGui = DateTime.Now },
    new LienHe { Id = 8, HoTen = "Võ Thị H", Email = "h@gmail.com", NoiDung = "Khách sạn có chỗ đậu xe không?", NgayGui = DateTime.Now },
    new LienHe { Id = 9, HoTen = "Lý Văn I", Email = "i@gmail.com", NoiDung = "Tôi bị mất mật khẩu đặt phòng.", NgayGui = DateTime.Now },
    new LienHe { Id = 10, HoTen = "Trịnh Thị K", Email = "k@gmail.com", NoiDung = "Khách sạn có dịch vụ spa không?", NgayGui = DateTime.Now }
);
            modelBuilder.Entity<DatPhong>().HasData(
           new DatPhong
           {
               Id = 1,
               HoTen = "Nguyễn Văn A",
               SoDienThoai = "0901234567",
               Email = "a@gmail.com",
               NgayNhan = DateTime.Today.AddDays(1),
               NgayTra = DateTime.Today.AddDays(3),
               SoNguoiLon = 2,
               SoTreEm = 1,
               ChiTietPhongId = 1,
               NgayDat = DateTime.Now,
               TrangThai = DatPhong.TrangThaiDatPhong.ChoXacNhan,
               LoaiPhong = LoaiPhong.Doi
           },
           new DatPhong
           {
               Id = 2,
               HoTen = "Trần Thị B",
               SoDienThoai = "0912345678",
               Email = "b@gmail.com",
               NgayNhan = DateTime.Today.AddDays(2),
               NgayTra = DateTime.Today.AddDays(5),
               SoNguoiLon = 1,
               SoTreEm = 0,
               ChiTietPhongId = 1,
               NgayDat = DateTime.Now,
               TrangThai = DatPhong.TrangThaiDatPhong.DaXacNhan,
               LoaiPhong = LoaiPhong.Doi
           },
           new DatPhong { Id = 3, HoTen = "Lê Văn C", SoDienThoai = "0934567890", Email = "c@gmail.com", NgayNhan = DateTime.Today, NgayTra = DateTime.Today.AddDays(2), SoNguoiLon = 2, SoTreEm = 2, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.ChoXacNhan, LoaiPhong = LoaiPhong.Doi },
           new DatPhong { Id = 4, HoTen = "Phạm Thị D", SoDienThoai = "0945678901", Email = "d@gmail.com", NgayNhan = DateTime.Today.AddDays(1), NgayTra = DateTime.Today.AddDays(4), SoNguoiLon = 3, SoTreEm = 0, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.DaHuy, LoaiPhong = LoaiPhong.Don },
           new DatPhong { Id = 5, HoTen = "Đỗ Văn E", SoDienThoai = "0956789012", Email = "e@gmail.com", NgayNhan = DateTime.Today.AddDays(2), NgayTra = DateTime.Today.AddDays(5), SoNguoiLon = 1, SoTreEm = 1, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.ChoXacNhan, LoaiPhong = LoaiPhong.Vip },
           new DatPhong { Id = 6, HoTen = "Bùi Thị F", SoDienThoai = "0967890123", Email = "f@gmail.com", NgayNhan = DateTime.Today.AddDays(3), NgayTra = DateTime.Today.AddDays(6), SoNguoiLon = 2, SoTreEm = 1, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.DaXacNhan, LoaiPhong = LoaiPhong.Doi },
           new DatPhong { Id = 7, HoTen = "Ngô Văn G", SoDienThoai = "0978901234", Email = "g@gmail.com", NgayNhan = DateTime.Today.AddDays(4), NgayTra = DateTime.Today.AddDays(7), SoNguoiLon = 4, SoTreEm = 2, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.ChoXacNhan, LoaiPhong = LoaiPhong.Don },
           new DatPhong { Id = 8, HoTen = "Võ Thị H", SoDienThoai = "0989012345", Email = "h@gmail.com", NgayNhan = DateTime.Today.AddDays(5), NgayTra = DateTime.Today.AddDays(8), SoNguoiLon = 2, SoTreEm = 0, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.DaHuy, LoaiPhong = LoaiPhong.Vip },
           new DatPhong { Id = 9, HoTen = "Lý Văn I", SoDienThoai = "0990123456", Email = "i@gmail.com", NgayNhan = DateTime.Today.AddDays(6), NgayTra = DateTime.Today.AddDays(9), SoNguoiLon = 1, SoTreEm = 1, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.DaXacNhan, LoaiPhong = LoaiPhong.Don },
           new DatPhong { Id = 10, HoTen = "Trịnh Thị K", SoDienThoai = "0901122334", Email = "k@gmail.com", NgayNhan = DateTime.Today.AddDays(7), NgayTra = DateTime.Today.AddDays(10), SoNguoiLon = 3, SoTreEm = 1, ChiTietPhongId = 1, NgayDat = DateTime.Now, TrangThai = DatPhong.TrangThaiDatPhong.ChoXacNhan, LoaiPhong = LoaiPhong.Doi }
       );
        }

    }
}
