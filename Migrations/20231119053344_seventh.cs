using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagement.Migrations
{
    public partial class seventh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKHoa_Don624260",
                table: "Hoa_Don");

            migrationBuilder.AddForeignKey(
                name: "FKHoa_Don624260",
                table: "Hoa_Don",
                column: "MaOrderPhong",
                principalTable: "Order_Phong",
                principalColumn: "MaOrderPhong",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKHoa_Don624260",
                table: "Hoa_Don");

            migrationBuilder.AddForeignKey(
                name: "FKHoa_Don624260",
                table: "Hoa_Don",
                column: "MaOrderPhong",
                principalTable: "Order_Phong",
                principalColumn: "MaOrderPhong");
        }
    }
}
