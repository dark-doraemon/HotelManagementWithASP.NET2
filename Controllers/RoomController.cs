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
        IHttpContextAccessor accessor;
        public RoomController(IRepository repo, IHttpContextAccessor accessor)
        {
            this.repo = repo;
            this.accessor = accessor;
        }

        LoaiPhongPhongTrangThaiPhong treetable = new LoaiPhongPhongTrangThaiPhong();

        [HttpGet]
        [HttpPost]
        public IActionResult Index(string loaiphong = null, string trangthaiphong = null, bool error = true)
        {
            if (loaiphong == null && trangthaiphong == null) treetable.phongs = repo.getPhongByLoaiPhong(null);
            else if (loaiphong == null) treetable.phongs = repo.getPhongByMaTrangThai(trangthaiphong);
            else if (trangthaiphong == null) treetable.phongs = repo.getPhongByLoaiPhong(loaiphong);

            treetable.trangthaiphongs = repo.getTrangThaiPhong;
            treetable.loaiphongs = repo.getLoaiPhong;
            treetable.dichvus = repo.getDichvu;
            treetable.error = error;
            if (accessor.HttpContext.Session.GetString("UserName") != null)
            {
                treetable.Person = repo.getPersonByUserName(accessor.HttpContext.Session.GetString("UserName"));
            }
            return View(treetable);
        }

        [Authentication]
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
            if (tuoi == 0 && gioitinh == 0 && cccd == null && sdt == null && ngayden == DateTime.MinValue && ngaydi == DateTime.MinValue)
            {
                 return RedirectToAction("Index", "Room",new {error = false});
            }
            Person person = new Person();
            if (accessor.HttpContext.Session.GetString("UserName") != null)
            {
                person = repo.getPersonByUserName(accessor.HttpContext.Session.GetString("UserName"));
            }
            else
            {
                person = new Person
                {
                    PersonId = cccd,
                    HoTen = hoten,
                    Tuoi = tuoi,
                    GioiTinh = gioitinh,
                    Sdt = sdt
                };
            }

            string maorderphong = repo.createOrderPhongId();
            OrderPhong orderphong = new OrderPhong
            {
                MaOrderPhong = maorderphong,
                NgayDen = ngayden,
                NgayDi = ngaydi,
                PersonId = cccd,
                MaPhong = maphong,
                Person = person,
                TrangThaiThanhToan = 0,
                MaPhongNavigation = repo.getPhongByMaPhong(maphong)
            };


            //đầu tiên add order phòng
            repo.addOrderPhong(orderphong);

            //tiếp theo add order phòng và danh sách dịch vụ của order phòng đó
            if (selectedServiceIds != null && selectedQuantities != null && servicePrice != null)
            {
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

                repo.addOrderPhongDichVu(orderphongdichvu);
            }


            //cuối cùng update trạng thái phòng là đăng thuê

            //người đăng kí phòng là user thì mã trạng thái phòng là đặt trước,nếu là admin thì trạng thái đang thuê
            if (accessor.HttpContext.Session.GetString("UserName") != null)
            {
                repo.updateTrangThaiPhong(maphong, "MTT3");
            }
            else repo.updateTrangThaiPhong(maphong, "MTT2");

            return RedirectToAction("Index", "Room", new { error = true });
        }


        [AdminOrNhanVienAuthentication]
        [Route("[controller]/[action]/{maphong}/{successOrFail?}")]
        public IActionResult thanhToan(string maphong, string successOrFail = "0")
        {
            //TrangThaiThanhToan == 0 : chưa thanh toán
            //TrangThaiThanhToan == 1: đã thanh toán
            OrderPhong order = repo.getOrderPhongByMaPhong(maphong).FirstOrDefault(od => od.TrangThaiThanhToan == 0);
            return View("thanhToan", order);
        }

        [AdminOrNhanVienAuthentication]
        [Route("[controller]/[action]/maorder")]
        public IActionResult addHoadon(string maorder, string tongtien, string maphong)
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

                //cập nhật lại trạng thái thanh toán của order phòng
                repo.updateTrangThaiOrderPhong(maorder);

                return View("ThanhToanThanhCong");
            }
            else
            {
                return RedirectToAction("thanhToan", "Room", new { maphong = maphong });
            }

        }

        [AdminOrNhanVienAuthentication]
        public IActionResult xacNhanDatPhong(string maphong)
        {
            //khi xác nhận đặt phòng thì phòng chuyển sang trạng thái đã đặt nghĩa là khách đang ở
            repo.updateTrangThaiPhong(maphong, "MTT2");
            return RedirectToAction("Index");
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
        public Person Person { get; set; } = null;
        public bool error { get; set; } = true;
    }

}
