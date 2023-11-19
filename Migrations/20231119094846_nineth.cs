using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class nineth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon460975",
                table: "Order_Phong");

            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon746646",
                table: "Order_Phong");

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon460975",
                table: "Order_Phong",
                column: "MaPhong",
                principalTable: "Phong",
                principalColumn: "MaPhong",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon746646",
                table: "Order_Phong",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon460975",
                table: "Order_Phong");

            migrationBuilder.DropForeignKey(
                name: "FKOrder_Phon746646",
                table: "Order_Phong");

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon460975",
                table: "Order_Phong",
                column: "MaPhong",
                principalTable: "Phong",
                principalColumn: "MaPhong");

            migrationBuilder.AddForeignKey(
                name: "FKOrder_Phon746646",
                table: "Order_Phong",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "PersonID");
        }
    }
}
