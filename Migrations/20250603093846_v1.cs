using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebsiteHotelManagerment.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DichVus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDichVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DichVus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LienHes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LienHes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phongs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdminReply = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TienNghi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoNguoiLon = table.Column<int>(type: "int", nullable: false),
                    SoTreEm = table.Column<int>(type: "int", nullable: false),
                    DienTich = table.Column<int>(type: "int", nullable: false),
                    GiaMoiDem = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TenFileAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieuDeAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoai = table.Column<int>(type: "int", nullable: false),
                    PhongId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiTietPhongs_Phongs_PhongId",
                        column: x => x.PhongId,
                        principalTable: "Phongs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiLon = table.Column<int>(type: "int", nullable: false),
                    TreEm = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ChiTietPhongId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ChiTietPhongs_ChiTietPhongId",
                        column: x => x.ChiTietPhongId,
                        principalTable: "ChiTietPhongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhToans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiTietPhongId = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HinhThucThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaThanhToan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhToans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhToans_ChiTietPhongs_ChiTietPhongId",
                        column: x => x.ChiTietPhongId,
                        principalTable: "ChiTietPhongs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatPhongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoNguoiLon = table.Column<int>(type: "int", nullable: false),
                    SoTreEm = table.Column<int>(type: "int", nullable: false),
                    ChiTietPhongId = table.Column<int>(type: "int", nullable: true),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    LoaiPhong = table.Column<int>(type: "int", nullable: false),
                    ThanhToanId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatPhongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatPhongs_ChiTietPhongs_ChiTietPhongId",
                        column: x => x.ChiTietPhongId,
                        principalTable: "ChiTietPhongs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DatPhongs_ThanhToans_ThanhToanId",
                        column: x => x.ThanhToanId,
                        principalTable: "ThanhToans",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ChiTietPhongs",
                columns: new[] { "Id", "DienTich", "GiaMoiDem", "MoTa", "PhanLoai", "PhongId", "SoNguoiLon", "SoTreEm", "TenFileAnh", "TenPhong", "TienNghi", "TieuDeAnh" },
                values: new object[,]
                {
                    { 1, 20, 500000m, "Phòng đơn nhỏ gọn", 0, null, 1, 0, "don1.png", "Phòng Đẹp VIP", "Wifi, TV", "Ảnh phòng đơn 1" },
                    { 2, 28, 700000m, "Phòng đôi thoáng mát", 1, null, 2, 1, "doi1.png", "Phòng Đôi 1", "Wifi, Điều hòa", "Ảnh phòng đôi 1" },
                    { 3, 35, 1200000m, "Phòng VIP tiện nghi cao cấp", 2, null, 3, 1, "vip1.png", "Phòng VIP 1", "Wifi, Điều hòa, Bồn tắm", "Ảnh phòng VIP 1" },
                    { 4, 22, 550000m, "Phòng đơn hiện đại", 0, null, 1, 0, "don2.png", "Phòng Đơn 2", "Wifi, TV", "Ảnh phòng đơn 2" },
                    { 5, 30, 750000m, "Phòng đôi ấm cúng", 1, null, 2, 1, "doi2.png", "Phòng Đôi 2", "Wifi, Điều hòa, TV", "Ảnh phòng đôi 2" },
                    { 6, 40, 1400000m, "Phòng VIP rộng rãi", 2, null, 4, 2, "vip2.png", "Phòng VIP 2", "Wifi, Điều hòa, TV, Bồn tắm", "Ảnh phòng VIP 2" },
                    { 7, 23, 520000m, "Phòng đơn giá rẻ", 0, null, 1, 1, "don3.png", "Phòng Đơn 3", "Wifi", "Ảnh phòng đơn 3" },
                    { 8, 29, 730000m, "Phòng đôi đơn giản", 1, null, 2, 0, "doi3.png", "Phòng Đôi 3", "Wifi, Điều hòa", "Ảnh phòng đôi 3" },
                    { 9, 38, 1350000m, "Phòng VIP sang trọng", 2, null, 3, 2, "vip3.png", "Phòng VIP 3", "Wifi, Điều hòa, Bồn tắm, TV", "Ảnh phòng VIP 3" },
                    { 10, 21, 510000m, "Phòng đơn yên tĩnh", 0, null, 1, 0, "don4.png", "Phòng Đơn 4", "Wifi, TV", "Ảnh phòng đơn 4" },
                    { 11, 32, 780000m, "Phòng đôi view đẹp", 1, null, 2, 2, "doi4.png", "Phòng Đôi 4", "Wifi, TV, Điều hòa", "Ảnh phòng đôi 4" },
                    { 12, 42, 1450000m, "Phòng VIP tiện nghi đầy đủ", 2, null, 4, 2, "vip4.png", "Phòng VIP 4", "Wifi, TV, Điều hòa, Bồn tắm", "Ảnh phòng VIP 4" },
                    { 13, 20, 490000m, "Phòng đơn nhỏ", 0, null, 1, 0, "don5.png", "Phòng Đơn 5", "Wifi", "Ảnh phòng đơn 5" },
                    { 14, 27, 710000m, "Phòng đôi sạch sẽ", 1, null, 2, 1, "doi5.png", "Phòng Đôi 5", "Wifi, Điều hòa", "Ảnh phòng đôi 5" },
                    { 15, 36, 1300000m, "Phòng VIP thoáng mát", 2, null, 3, 2, "vip5.png", "Phòng VIP 5", "Wifi, Điều hòa, TV", "Ảnh phòng VIP 5" },
                    { 16, 24, 530000m, "Phòng đơn tiện nghi", 0, null, 1, 1, "don6.png", "Phòng Đơn 6", "Wifi, Điều hòa", "Ảnh phòng đơn 6" },
                    { 17, 31, 760000m, "Phòng đôi hiện đại", 1, null, 2, 2, "doi6.png", "Phòng Đôi 6", "Wifi, TV", "Ảnh phòng đôi 6" },
                    { 18, 43, 1500000m, "Phòng VIP cao cấp", 2, null, 4, 1, "vip6.png", "Phòng VIP 6", "Wifi, Điều hòa, TV, Bồn tắm", "Ảnh phòng VIP 6" },
                    { 19, 20, 500000m, "Phòng đơn yên bình", 0, null, 1, 0, "don7.png", "Phòng Đơn 7", "Wifi, TV", "Ảnh phòng đơn 7" },
                    { 20, 29, 740000m, "Phòng đôi sạch sẽ", 1, null, 2, 1, "doi7.png", "Phòng Đôi 7", "Wifi, Điều hòa", "Ảnh phòng đôi 7" },
                    { 21, 39, 1380000m, "Phòng VIP hiện đại", 2, null, 3, 2, "vip7.png", "Phòng VIP 7", "Wifi, Điều hòa, TV", "Ảnh phòng VIP 7" },
                    { 22, 22, 520000m, "Phòng đơn tiết kiệm", 0, null, 1, 1, "don8.png", "Phòng Đơn 8", "Wifi", "Ảnh phòng đơn 8" },
                    { 23, 33, 790000m, "Phòng đôi thoải mái", 1, null, 2, 2, "doi8.png", "Phòng Đôi 8", "Wifi, TV, Điều hòa", "Ảnh phòng đôi 8" },
                    { 24, 45, 1550000m, "Phòng VIP đẳng cấp", 2, null, 4, 2, "vip8.png", "Phòng VIP 8", "Wifi, TV, Điều hòa, Bồn tắm", "Ảnh phòng VIP 8" },
                    { 25, 21, 500000m, "Phòng đơn thư giãn", 0, null, 1, 0, "don9.png", "Phòng Đơn 9", "Wifi", "Ảnh phòng đơn 9" },
                    { 26, 30, 750000m, "Phòng đôi tiện nghi", 1, null, 2, 1, "doi9.png", "Phòng Đôi 9", "Wifi, TV", "Ảnh phòng đôi 9" },
                    { 27, 41, 1450000m, "Phòng VIP ấm cúng", 2, null, 3, 2, "vip9.png", "Phòng VIP 9", "Wifi, Điều hòa, Bồn tắm", "Ảnh phòng VIP 9" },
                    { 28, 23, 510000m, "Phòng đơn tiện lợi", 0, null, 1, 0, "don10.png", "Phòng Đơn 10", "Wifi, TV", "Ảnh phòng đơn 10" },
                    { 29, 28, 720000m, "Phòng đôi phổ thông", 1, null, 2, 1, "doi10.png", "Phòng Đôi 10", "Wifi, Điều hòa", "Ảnh phòng đôi 10" },
                    { 30, 44, 1600000m, "Phòng VIP rộng và đẹp", 2, null, 4, 2, "vip10.png", "Phòng VIP 10", "Wifi, TV, Bồn tắm", "Ảnh phòng VIP 10" }
                });

            migrationBuilder.InsertData(
                table: "LienHes",
                columns: new[] { "Id", "Email", "HoTen", "NgayGui", "NoiDung" },
                values: new object[,]
                {
                    { 1, "a@gmail.com", "Nguyễn Văn A", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8375), "Tôi cần hỗ trợ đặt phòng." },
                    { 2, "b@gmail.com", "Trần Thị B", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8377), "Khách sạn có hồ bơi không?" },
                    { 3, "c@gmail.com", "Lê Văn C", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8378), "Phòng đơn giá bao nhiêu?" },
                    { 4, "d@gmail.com", "Phạm Thị D", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8380), "Check-in lúc mấy giờ?" },
                    { 5, "e@gmail.com", "Đỗ Văn E", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8382), "Tôi muốn đổi lịch nhận phòng." },
                    { 6, "f@gmail.com", "Bùi Thị F", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8383), "Có phục vụ ăn sáng không?" },
                    { 7, "g@gmail.com", "Ngô Văn G", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8385), "Tôi muốn huỷ phòng đã đặt." },
                    { 8, "h@gmail.com", "Võ Thị H", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8387), "Khách sạn có chỗ đậu xe không?" },
                    { 9, "i@gmail.com", "Lý Văn I", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8388), "Tôi bị mất mật khẩu đặt phòng." },
                    { 10, "k@gmail.com", "Trịnh Thị K", new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8390), "Khách sạn có dịch vụ spa không?" }
                });

            migrationBuilder.InsertData(
                table: "DatPhongs",
                columns: new[] { "Id", "ChiTietPhongId", "Email", "HoTen", "LoaiPhong", "NgayDat", "NgayNhan", "NgayTra", "SoDienThoai", "SoNguoiLon", "SoTreEm", "ThanhToanId", "TrangThai" },
                values: new object[,]
                {
                    { 1, 1, "a@gmail.com", "Nguyễn Văn A", 1, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8581), new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), "0901234567", 2, 1, null, 0 },
                    { 2, 1, "b@gmail.com", "Trần Thị B", 1, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8590), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), "0912345678", 1, 0, null, 1 },
                    { 3, 1, "c@gmail.com", "Lê Văn C", 1, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8598), new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), "0934567890", 2, 2, null, 0 },
                    { 4, 1, "d@gmail.com", "Phạm Thị D", 0, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8605), new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), "0945678901", 3, 0, null, 2 },
                    { 5, 1, "e@gmail.com", "Đỗ Văn E", 2, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8612), new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), "0956789012", 1, 1, null, 0 },
                    { 6, 1, "f@gmail.com", "Bùi Thị F", 1, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8619), new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), "0967890123", 2, 1, null, 1 },
                    { 7, 1, "g@gmail.com", "Ngô Văn G", 0, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8627), new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), "0978901234", 4, 2, null, 0 },
                    { 8, 1, "h@gmail.com", "Võ Thị H", 2, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8635), new DateTime(2025, 6, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 11, 0, 0, 0, 0, DateTimeKind.Local), "0989012345", 2, 0, null, 2 },
                    { 9, 1, "i@gmail.com", "Lý Văn I", 0, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8642), new DateTime(2025, 6, 9, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Local), "0990123456", 1, 1, null, 1 },
                    { 10, 1, "k@gmail.com", "Trịnh Thị K", 1, new DateTime(2025, 6, 3, 16, 38, 46, 62, DateTimeKind.Local).AddTicks(8649), new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Local), "0901122334", 3, 1, null, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhongs_PhongId",
                table: "ChiTietPhongs",
                column: "PhongId");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_ChiTietPhongId",
                table: "DatPhongs",
                column: "ChiTietPhongId");

            migrationBuilder.CreateIndex(
                name: "IX_DatPhongs_ThanhToanId",
                table: "DatPhongs",
                column: "ThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ChiTietPhongId",
                table: "Orders",
                column: "ChiTietPhongId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToans_ChiTietPhongId",
                table: "ThanhToans",
                column: "ChiTietPhongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DatPhongs");

            migrationBuilder.DropTable(
                name: "DichVus");

            migrationBuilder.DropTable(
                name: "LienHes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ThanhToans");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ChiTietPhongs");

            migrationBuilder.DropTable(
                name: "Phongs");
        }
    }
}
