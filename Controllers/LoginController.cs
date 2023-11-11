using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class LoginController : Controller
    {

        private IRepository repo;
        public LoginController(IRepository repo)
        {
            this.repo = repo;   
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(TaiKhoan account)
        {
            if (repo.CheckAccount(account))
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("", "Tk hoac mk k chinh xac");
                return View();
            }
        }
    }
}
