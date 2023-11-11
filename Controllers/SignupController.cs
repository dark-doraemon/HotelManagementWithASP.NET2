using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace HotelManagement.Controllers
{
    public class SignupController : Controller
    {

        private IRepository repo;
        public SignupController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            PersonAndAccount p = new PersonAndAccount();
            return View(p);
        }

        [HttpPost]
        public IActionResult Index(PersonAndAccount paa)
        {
            if (paa.confirm != paa.a.Password)
            {
                ModelState.AddModelError("", "Mật khẩu không giống nhau");
            }
            else
            {
                repo.CreateAccount(new TaiKhoan
                {
                    MaTaiKhoan = "TK2",
                    UserName = paa.a.UserName,
                    Password = paa.a.Password,
                    LoaiTaiKhoan = "LTK3",
                    Person = paa.p
                }); 
            }
            return View();
        }
    }

    public class PersonAndAccount
    {
        public Person p { get; set; }
        public TaiKhoan a { get; set; }
        public string confirm { get; set; }
    }
}
