using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repo;
        public HomeController(IRepository repository)
        {
            this.repo = repository;
        }

       
        [HttpGet]
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
