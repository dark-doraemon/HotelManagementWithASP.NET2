using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models.Authentication;
namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {

        [Authentication] // (hàm tự build) nó sẽ kiểm tra season xem người dùng đã đăng nhập chưa
        public IActionResult Index()
        {
            return View();
        }
    }
}
