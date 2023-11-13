using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult QLPhong()
        {
            return View();
        }

        public IActionResult QLDichVu()
        {
            return View();
        }
    }
}
