using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon17642",
                table: "Order_Phong_Dich_Vu");

            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon597344",
                table: "Order_Phong_Dich_Vu");

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon17642",
                table: "Order_Phong_Dich_Vu",
                column: "MaOrderPhong",
                principalTable: "Order_Phong",
                principalColumn: "MaOrderPhong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon597344",
                table: "Order_Phong_Dich_Vu",
                column: "MaDichVu",
                principalTable: "Dich_Vu",
                principalColumn: "MaDichVu",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon17642",
                table: "Order_Phong_Dich_Vu");

            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon597344",
                table: "Order_Phong_Dich_Vu");

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon17642",
                table: "Order_Phong_Dich_Vu",
                column: "MaOrderPhong",
                principalTable: "Order_Phong",
                principalColumn: "MaOrderPhong");

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon597344",
                table: "Order_Phong_Dich_Vu",
                column: "MaDichVu",
                principalTable: "Dich_Vu",
                principalColumn: "MaDichVu");
        }
    }
}
