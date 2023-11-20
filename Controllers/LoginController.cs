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
            httpContextAccessor.HttpContext.Session.Clear();

            //Kiểm tra account có trong CSDL không
            TaiKhoan check = repo.CheckAccount(account);
            if (check != null)
            {
                if (repo.CheckAccount(account).LoaiTaiKhoan == "LTK1")
                {
                    httpContextAccessor.HttpContext.Session.SetString("admin", account.UserName);
                }

                else if (repo.CheckAccount(account).LoaiTaiKhoan == "LTK2")
                {
                    httpContextAccessor.HttpContext.Session.SetString("nhanvien", account.UserName);
                }
                else
                {
                    httpContextAccessor.HttpContext.Session.SetString("UserName", account.UserName);
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không chính xác");
            return View();
        }


        public IActionResult Logout()
        {
            httpContextAccessor.HttpContext.Session.Clear();
            httpContextAccessor.HttpContext.Session.Remove("UserName");
            httpContextAccessor.HttpContext.Session.Remove("nhanvien");
            httpContextAccessor.HttpContext.Session.Remove("admin");

            return RedirectToAction("Index", "Home");
        }
    }
}
