using HotelManagement.DataAccess;
using HotelManagement.Models;
using HotelManagement.Models.Authentication;
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

        [Authentication]
        public IActionResult Index()
        {
            //đầu tiên lấy Person
            string userName = accessor.HttpContext.Session.GetString("UserName");
            Person p = repo.getPersonByUserName(userName);


            //từ person lấy ra OrderPhong của person đó
            IEnumerable<OrderPhong> oderPhongs = repo.getOrderPhongByPerson(p.PersonId);
            return View(oderPhongs);
        }

        [Authentication]
        public IActionResult removeOrder(string maorder,string maphong)
        {
            repo.removeOrderPhong(maorder);
            //sau khí xóa order phòng xong thì cập nhật lại trạng thái là trống

            repo.updateTrangThaiPhong(maphong, "MTT1");
            return RedirectToAction("Index");
        }
    }
}
