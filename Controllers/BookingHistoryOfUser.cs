using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HotelManagement.Controllers
{
    public class BookingHistoryOfUser : Controller
    {
        private IRepository repo;
        private IHttpContextAccessor accessor;
        public BookingHistoryOfUser(IRepository repo,IHttpContextAccessor accessor)
        {
            this.repo = repo;
            this.accessor = accessor;
        }
        public IActionResult Index()
        {
            //đầu tiên lấy Person
            string userName = accessor.HttpContext.Session.GetString("UserName");
            Person p = repo.getPersonByUserName(userName);


            //từ person lấy ra OrderPhong của person đó
            IEnumerable<OrderPhong> oderPhongs = repo.getOrdrPhongByPerson(p);
            return View(oderPhongs);
        }
    }
}
