using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dich_Vu",
                columns: table => new
                {
                    MaDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GiaDichVu = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Dich_Vu__C0E6DE8FC72B2A69", x => x.MaDichVu);
                });

            migrationBuilder.CreateTable(
                name: "Loai_Phong",
                columns: table => new
                {
                    MaLoaiPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenLoaiPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GiaPhong = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loai_Pho__23021217A48C92C2", x => x.MaLoaiPhong);
                });

            migrationBuilder.CreateTable(
                name: "Loai_Tai_Khoan",
                columns: table => new
                {
                    MaLoaiTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Loai_Tai__5F6E141C07C4DC2B", x => x.MaLoaiTaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tuoi = table.Column<int>(type: "int", nullable: false),
                    GioiTinh = table.Column<int>(type: "int", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Trang_Thai_Phong",
                columns: table => new
                {
                    MaTrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenTrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trang_Th__AADE41383344BB34", x => x.MaTrangThai);
                });

            migrationBuilder.CreateTable(
                name: "Vai_Tro",
                columns: table => new
                {
                    MaVaiTro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vai_Tro__C24C41CFA446BD32", x => x.MaVaiTro);
                });

            migrationBuilder.CreateTable(
                name: "Khach_Hang",
                columns: table => new
                {
                    KhachHang_ID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khach_Hang", x => x.KhachHang_ID);
                    table.ForeignKey(
                        name: "FKKhach_Hang279424",
                        column: x => x.KhachHang_ID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "Tai_Khoan",
                columns: table => new
                {
                    MaTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LoaiTaiKhoan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tai_Khoa__AD7C6529EF10FB2D", x => x.MaTaiKhoan);
                    table.ForeignKey(
                        name: "FKTai_Khoan172310",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FKTai_Khoan92928",
                        column: x => x.LoaiTaiKhoan,
                        principalTable: "Loai_Tai_Khoan",
                        principalColumn: "MaLoaiTaiKhoan");
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    MaPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TenPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTaPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaTrangThai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaLoaiPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Phong__20BD5E5B177E3D28", x => x.MaPhong);
                    table.ForeignKey(
                        name: "FKPhong128242",
                        column: x => x.MaTrangThai,
                        principalTable: "Trang_Thai_Phong",
                        principalColumn: "MaTrangThai");
                    table.ForeignKey(
                        name: "FKPhong134689",
                        column: x => x.MaLoaiPhong,
                        principalTable: "Loai_Phong",
                        principalColumn: "MaLoaiPhong",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nhan_Vien",
                columns: table => new
                {
                    NhanVienID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaVaiTro = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayDuocTuyen = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhan_Vien", x => x.NhanVienID);
                    table.ForeignKey(
                        name: "FKNhan_Vien605300",
                        column: x => x.NhanVienID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                    table.ForeignKey(
                        name: "FKNhan_Vien799741",
                        column: x => x.MaVaiTro,
                        principalTable: "Vai_Tro",
                        principalColumn: "MaVaiTro");
                });

            migrationBuilder.CreateTable(
                name: "Order_Phong",
                columns: table => new
                {
                    MaOrderPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayDen = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayDi = table.Column<DateTime>(type: "datetime", nullable: true),
                    PersonID = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_Ph__829E7C7605A5F40A", x => x.MaOrderPhong);
                    table.ForeignKey(
                        name: "FKOrder_Phon460975",
                        column: x => x.MaPhong,
                        principalTable: "Phong",
                        principalColumn: "MaPhong");
                    table.ForeignKey(
                        name: "FKOrder_Phon746646",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "Hoa_Don",
                columns: table => new
                {
                    MaHoaDon = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NgayIn = table.Column<DateTime>(type: "datetime", nullable: true),
                    TongTien = table.Column<float>(type: "real", nullable: false),
                    MaOrderPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hoa_Don__835ED13B118615AA", x => x.MaHoaDon);
                    table.ForeignKey(
                        name: "FKHoa_Don624260",
                        column: x => x.MaOrderPhong,
                        principalTable: "Order_Phong",
                        principalColumn: "MaOrderPhong");
                });

            migrationBuilder.CreateTable(
                name: "Order_Phong_Dich_Vu",
                columns: table => new
                {
                    MaOrderPhong = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaDichVu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order_Ph__6E90119E9EC16A77", x => new { x.MaOrderPhong, x.MaDichVu });
                    table.ForeignKey(
                        name: "FKOrder_Phon17642",
                        column: x => x.MaOrderPhong,
                        principalTable: "Order_Phong",
                        principalColumn: "MaOrderPhong");
                    table.ForeignKey(
                        name: "FKOrder_Phon597344",
                        column: x => x.MaDichVu,
                        principalTable: "Dich_Vu",
                        principalColumn: "MaDichVu");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_Don_MaOrderPhong",
                table: "Hoa_Don",
                column: "MaOrderPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Nhan_Vien_MaVaiTro",
                table: "Nhan_Vien",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Phong_MaPhong",
                table: "Order_Phong",
                column: "MaPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Phong_PersonID",
                table: "Order_Phong",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Phong_Dich_Vu_MaDichVu",
                table: "Order_Phong_Dich_Vu",
                column: "MaDichVu");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_MaLoaiPhong",
                table: "Phong",
                column: "MaLoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_MaTrangThai",
                table: "Phong",
                column: "MaTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_Tai_Khoan_LoaiTaiKhoan",
                table: "Tai_Khoan",
                column: "LoaiTaiKhoan");

            migrationBuilder.CreateIndex(
                name: "IX_Tai_Khoan_PersonID",
                table: "Tai_Khoan",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hoa_Don");

            migrationBuilder.DropTable(
                name: "Khach_Hang");

            migrationBuilder.DropTable(
                name: "Nhan_Vien");

            migrationBuilder.DropTable(
                name: "Order_Phong_Dich_Vu");

            migrationBuilder.DropTable(
                name: "Tai_Khoan");

            migrationBuilder.DropTable(
                name: "Vai_Tro");

            migrationBuilder.DropTable(
                name: "Order_Phong");

            migrationBuilder.DropTable(
                name: "Dich_Vu");

            migrationBuilder.DropTable(
                name: "Loai_Tai_Khoan");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Trang_Thai_Phong");

            migrationBuilder.DropTable(
                name: "Loai_Phong");
        }
    }
}
