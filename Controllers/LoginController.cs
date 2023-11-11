using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
