using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models.Authentication;
using HotelManagement.DataAccess;
using HotelManagement.Models;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        private IRepository repo;
        public RoomController(IRepository repo)
        {
            this.repo = repo;
        }
        LoaiPhongPhongTrangThaiPhong treetable = new LoaiPhongPhongTrangThaiPhong();
        [HttpGet]
        [HttpPost]
        public IActionResult Index(string loaiphong = null,string trangthaiphong = null)
        {
            if (loaiphong == null && trangthaiphong == null) treetable.phongs = repo.getPhong(null);
            else if (loaiphong == null) treetable.phongs = repo.getPhongByMaTrangThai(trangthaiphong);
            else if (trangthaiphong == null) treetable.phongs = repo.getPhong(loaiphong);

            treetable.trangthaiphongs = repo.getTrangThaiPhong;
            treetable.loaiphongs = repo.getLoaiPhong;
            treetable.dichvus = repo.getDichvu;
            return View(treetable);
        }

        public IActionResult datPhong()
        {
            return View();
        }
       
    }

    public class LoaiPhongPhongTrangThaiPhong
    {
        public LoaiPhongPhongTrangThaiPhong()
        {
            
        }
        public IEnumerable<LoaiPhong> loaiphongs { get; set; }   
        public IEnumerable<Phong> phongs { get; set; }
        public IEnumerable<TrangThaiPhong> trangthaiphongs { get; set; }
        public IEnumerable<DichVu> dichvus { get; set; }
    }

}
