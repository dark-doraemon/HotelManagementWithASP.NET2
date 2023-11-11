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
        public IActionResult Index()
        {

            var s = repo.getPeople;
            return View(s);
        }

    }
}
