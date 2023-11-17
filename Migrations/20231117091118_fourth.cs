using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Phong_MaPhong",
                table: "Order_Phong");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Phong_MaPhong",
                table: "Order_Phong",
                column: "MaPhong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_Phong_MaPhong",
                table: "Order_Phong");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Phong_MaPhong",
                table: "Order_Phong",
                column: "MaPhong",
                unique: true,
                filter: "[MaPhong] IS NOT NULL");
        }
    }
}
