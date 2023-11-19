using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class eighth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKKhach_Hang279424",
                table: "Khach_Hang");

            migrationBuilder.DropForeignKey(
                name: "FKNhan_Vien605300",
                table: "Nhan_Vien");

            migrationBuilder.DropForeignKey(
                name: "FKNhan_Vien799741",
                table: "Nhan_Vien");

            migrationBuilder.DropForeignKey(
                name: "FKTai_Khoan172310",
                table: "Tai_Khoan");

            migrationBuilder.DropForeignKey(
                name: "FKTai_Khoan92928",
                table: "Tai_Khoan");

            migrationBuilder.AddForeignKey(
                name: "FKKhach_Hang279424",
                table: "Khach_Hang",
                column: "KhachHang_ID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKNhan_Vien605300",
                table: "Nhan_Vien",
                column: "NhanVienID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKNhan_Vien799741",
                table: "Nhan_Vien",
                column: "MaVaiTro",
                principalTable: "Vai_Tro",
                principalColumn: "MaVaiTro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKTai_Khoan172310",
                table: "Tai_Khoan",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKTai_Khoan92928",
                table: "Tai_Khoan",
                column: "LoaiTaiKhoan",
                principalTable: "Loai_Tai_Khoan",
                principalColumn: "MaLoaiTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKKhach_Hang279424",
                table: "Khach_Hang");

            migrationBuilder.DropForeignKey(
                name: "FKNhan_Vien605300",
                table: "Nhan_Vien");

            migrationBuilder.DropForeignKey(
                name: "FKNhan_Vien799741",
                table: "Nhan_Vien");

            migrationBuilder.DropForeignKey(
                name: "FKTai_Khoan172310",
                table: "Tai_Khoan");

            migrationBuilder.DropForeignKey(
                name: "FKTai_Khoan92928",
                table: "Tai_Khoan");

            migrationBuilder.AddForeignKey(
                name: "FKKhach_Hang279424",
                table: "Khach_Hang",
                column: "KhachHang_ID",
                principalTable: "Person",
                principalColumn: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FKNhan_Vien605300",
                table: "Nhan_Vien",
                column: "NhanVienID",
                principalTable: "Person",
                principalColumn: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FKNhan_Vien799741",
                table: "Nhan_Vien",
                column: "MaVaiTro",
                principalTable: "Vai_Tro",
                principalColumn: "MaVaiTro");

            migrationBuilder.AddForeignKey(
                name: "FKTai_Khoan172310",
                table: "Tai_Khoan",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FKTai_Khoan92928",
                table: "Tai_Khoan",
                column: "LoaiTaiKhoan",
                principalTable: "Loai_Tai_Khoan",
                principalColumn: "MaLoaiTaiKhoan");
        }
    }
}
