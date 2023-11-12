using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
namespace HotelManagement.Controllers
{
    public class LoginController : Controller
    {

        private IRepository repo;
        private IHttpContextAccessor httpContextAccessor;
        public LoginController(IRepository repo, IHttpContextAccessor accessor)
        {
            this.repo = repo;
            this.httpContextAccessor = accessor;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(TaiKhoan account)
        {
            //khi đăng nhập phải check xem session có account chưa
            if (httpContextAccessor.HttpContext.Session.GetString(account.UserName) == null)
            {
                //Kiểm tra account có trong CSDL không
                if (repo.CheckAccount(account))
                {
                    httpContextAccessor.HttpContext.Session.SetString("UserName", account.UserName);
                    return RedirectToAction("Index", "Home", account);
                }
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
            }
            return View();
        }


        public IActionResult Logout()
        {
            httpContextAccessor.HttpContext.Session.Clear();
            httpContextAccessor.HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index", "Home");
        }
    }
}
