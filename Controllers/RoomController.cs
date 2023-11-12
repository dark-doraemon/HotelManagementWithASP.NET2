using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models.Authentication;
namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {

        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
    }
}
