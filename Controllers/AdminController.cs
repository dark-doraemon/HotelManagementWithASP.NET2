using HotelManagement.DataAccess;
using HotelManagement.Models;
using HotelManagement.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class AdminController : Controller
    {
        private IRepository repo;
        public AdminController(IRepository repo)
        {
            this.repo = repo;   
        }

        [HttpGet]
        [HttpPost]
        [AdminAuthentication]
        public IActionResult QLPhong(string id)
        {
            var loaiphong = repo.getLoaiPhong.ToList();
            var phong = repo.getPhongByLoaiPhong(id).ToList();
            var trangthaiphong = repo.getTrangThaiPhong.ToList();
            return View(new LoaiPhongAndPhong { lp = loaiphong, p = phong ,ttp = trangthaiphong});
        }

        [Route("[controller]/phong/[action]/{maloaiphong}")]
        [AdminAuthentication]
        public IActionResult removeLoaiPhong(string maloaiphong)
        {
            repo.removeLoaiPhong(maloaiphong);
            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        [HttpPost]
        public IActionResult themLoaiPhong(string maloaiphong,string tenloaiphong,float gialoaiphong)
        {
            LoaiPhong newLoaiPhong = new LoaiPhong
            {
                MaLoaiPhong = maloaiphong,
                TenLoaiPhong = tenloaiphong,
                GiaPhong = gialoaiphong,
            };
            repo.themLoaiPhong(newLoaiPhong);

            return RedirectToAction("QLPhong");

        }

        [AdminAuthentication]
        public IActionResult suaLoaiPhong(string maloaiphong, string tenloaiphong, float gialoaiphong)
        {
            repo.suaLoaiPhong(new LoaiPhong { MaLoaiPhong = maloaiphong,TenLoaiPhong= tenloaiphong ,GiaPhong = gialoaiphong});
            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        public IActionResult themPhong(string maphong,string tenphong,string motaphong,string matrangthai,string maloaiphong)
        {
            repo.themPhong(new Phong { 
                                    MaPhong = maphong,
                                    TenPhong= tenphong,
                                    MoTaPhong = motaphong,
                                    MaTrangThai = matrangthai,
                                    MaLoaiPhong = maloaiphong  });

            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        [Route("[controller]/phong/[action]/{maphong}")]
        public IActionResult xoaPhong(string maphong)
        {
            repo.xoaPhong(maphong);
            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        public IActionResult suaPhong(string maphong,string tenphong,string motaphong,string matrangthai,string maloaiphong)
        {
            repo.suaPhong(new Phong
                                    {
                                        MaPhong = maphong,
                                        TenPhong = tenphong,
                                        MoTaPhong = motaphong,
                                        MaTrangThai = matrangthai,
                                        MaLoaiPhong = maloaiphong
                                    });
            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        public IActionResult QLDichVu()
        {

            return View();
        }

        [AdminAuthentication]
        public IActionResult QLHoaDon()
        {
            return View(repo.GetHoaDon);
        }

        [AdminAuthentication]
        public IActionResult chiTietHoaDon(string mahoadon)
        {
            var s = repo.getChiTietHoaDon(mahoadon).FirstOrDefault();
            return View(s);
        }

        //khi xóa hóa đơn thì ta nên xóa order phòng
        [AdminAuthentication]
        public IActionResult xoaHoadon(string maorder)
        {
            repo.removeOrderPhong(maorder);
            return RedirectToAction("QLHoaDon");
        }

        [AdminAuthentication]
        public IActionResult QLUser()
        {
            
            return View(repo.getKhachHang);
        }


        [AdminAuthentication]
        public IActionResult QLNhanVien()
        {
            return View();
        }

        [AdminAuthentication]
        public IActionResult updateThongTinKhachHang(string personid,string hoten,int tuoi,int gioitinh, string sdt)
        {
            return RedirectToAction("QLUser");
        }

        [AdminAuthentication]
        public IActionResult xoaKhachHang(string personid)
        {
            var orderphongs = repo.getOrdrPhongByPerson(personid);

            //khi xóa khách hàng xong thì những phòng mà khách hàng order phải xóa theo
            //mà khi order phòng bị xóa thì trạng thái phòng phải chuyển sang thành là "trống" (MTT1)
            foreach (var orderphong in orderphongs)
            {
                repo.updateTrangThaiPhong(orderphong.MaPhongNavigation.MaPhong, "MTT1");
            }

            repo.removeKhachHang(personid);



            return RedirectToAction("QLUser");
        }
    }

    public class LoaiPhongAndPhong
    {
        public List<LoaiPhong> lp { get;set; }
        public List<Phong> p { get; set; }    
        public List<TrangThaiPhong> ttp { get; set; }
    }
}
