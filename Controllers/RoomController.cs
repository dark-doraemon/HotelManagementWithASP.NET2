using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.Models.Authentication;
using HotelManagement.DataAccess;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore.Metadata;

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
            if (loaiphong == null && trangthaiphong == null) treetable.phongs = repo.getPhongByLoaiPhong(null);
            else if (loaiphong == null) treetable.phongs = repo.getPhongByMaTrangThai(trangthaiphong);
            else if (trangthaiphong == null) treetable.phongs = repo.getPhongByLoaiPhong(loaiphong);

            treetable.trangthaiphongs = repo.getTrangThaiPhong;
            treetable.loaiphongs = repo.getLoaiPhong;
            treetable.dichvus = repo.getDichvu;
            return View(treetable);
        }

        
        public IActionResult datPhongVaDichVu(string hoten,
            int tuoi,
            int gioitinh,
            string cccd,
            string sdt,
            DateTime ngayden,
            DateTime ngaydi,
            string maphong,
            string selectedServiceIds,
            string servicePrice,
            string selectedQuantities)
        {
            Person person = new Person
            {
                PersonId = cccd,
                HoTen = hoten,
                Tuoi = tuoi,
                GioiTinh = gioitinh,
                Sdt = sdt,
            };

            string maorderphong = repo.createOrderPhongId();
            OrderPhong orderphong = new OrderPhong
            {
                MaOrderPhong = maorderphong,
                NgayDen = ngayden,
                NgayDi = ngaydi,
                PersonId = cccd,
                MaPhong = maphong,
                Person = person,
                MaPhongNavigation = repo.getPhongByMaPhong(maphong)
            };


           

            List<string> madichvu = selectedServiceIds.Split(',').ToList();
            List<int> soLuongMoiDichVu = selectedQuantities.Split(",").Select(int.Parse).ToList();
            List<float> giaMoiDichVu = servicePrice.Split(",").Select(float.Parse).ToList();

            List<OrderPhongDichVu> orderphongdichvu = new List<OrderPhongDichVu>();
            for (int i = 0; i < madichvu.Count(); i++)
            {
                orderphongdichvu.Add(new OrderPhongDichVu
                {
                    MaOrderPhong = maorderphong,
                    MaDichVu = madichvu[i],
                    SoLuong = soLuongMoiDichVu[i],
                    DonGia = giaMoiDichVu[i]
                });
            }
            //đầu tiên add order phòng
            repo.addOrderPhong(orderphong);

            //tiếp theo add order phòng và danh sách dịch vụ của order phòng đó
            repo.addOrderPhongDichVu(orderphongdichvu);


            //cuối cùng update trạng thái phòng là đăng thuê
            repo.updateTrangThaiPhong(maphong, "MTT2");
            return RedirectToAction("Index","Room",new { maorder = maorderphong });
        }

        [Route("[controller]/[action]/{maphong}/{successOrFail?}")]
        public IActionResult thanhToan(string maphong,string successOrFail = "0")
        {
            OrderPhong order = repo.getOrderPhongByMaPhong(maphong).FirstOrDefault();
            return View("thanhToan",new OrderPhongVaTrangThai { orderPhong = order, trangthai = successOrFail } );
        }

        [Route("[controller]/[action]/maorder")]
        public IActionResult addHoadon(string maorder,string tongtien,string maphong)
        {
            HoaDon hd = new HoaDon
            {
                MaHoaDon = repo.createHoaDonId(),
                NgayIn = DateTime.Now,
                TongTien = float.Parse(tongtien),
                MaOrderPhong = maorder,
            };

            bool checkHoaDonOrderPHong = repo.addHoaDon(hd);
            if (checkHoaDonOrderPHong)
            {
                //sao khi thanh toán thì cập nhật trạng thái phòng lại
                repo.updateTrangThaiPhong(maphong, "MTT1");

                return RedirectToAction("thanhToan", "Room", new { maphong = maphong, successOrFail = "1" });
            }
            else
            {
                return RedirectToAction("thanhToan", "Room", new { maphong = maphong, successOrFail = "2" });
            }

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

    public class OrderPhongVaTrangThai
    {
        public OrderPhongVaTrangThai() { }

        public OrderPhong orderPhong { get; set; }

        public string trangthai { get; set; }
    }

}
