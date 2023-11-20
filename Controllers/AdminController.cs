﻿using HotelManagement.DataAccess;
using HotelManagement.Models;
using HotelManagement.Models.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

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
            return View(new LoaiPhongAndPhong { lp = loaiphong, p = phong, ttp = trangthaiphong });
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
        public IActionResult themLoaiPhong(string maloaiphong, string tenloaiphong, float gialoaiphong)
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
            repo.suaLoaiPhong(new LoaiPhong { MaLoaiPhong = maloaiphong, TenLoaiPhong = tenloaiphong, GiaPhong = gialoaiphong });
            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        public IActionResult themPhong(string maphong, string tenphong, string motaphong, string matrangthai, string maloaiphong)
        {
            repo.themPhong(new Phong
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
        [Route("[controller]/phong/[action]/{maphong}")]
        public IActionResult xoaPhong(string maphong)
        {
            repo.xoaPhong(maphong);
            return RedirectToAction("QLPhong");
        }

        [AdminAuthentication]
        public IActionResult suaPhong(string maphong, string tenphong, string motaphong, string matrangthai, string maloaiphong)
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

        [AdminOrNhanVienAuthentication]
        public IActionResult QLHoaDon()
        {
            return View(repo.GetHoaDon);
        }


        [AdminOrNhanVienAuthentication]
        public IActionResult chiTietHoaDon(string mahoadon)
        {
            var s = repo.getChiTietHoaDon(mahoadon).FirstOrDefault();
            return View(s);
        }

        //khi xóa hóa đơn thì ta nên xóa order phòng
        [AdminOrNhanVienAuthentication]
        public IActionResult xoaHoadon(string maorder)
        {
            repo.removeOrderPhong(maorder);
            return RedirectToAction("QLHoaDon");
        }

        [AdminOrNhanVienAuthentication]
        public IActionResult QLUser()
        {

            return View(repo.getKhachHang);
        }



        [AdminOrNhanVienAuthentication]
        public IActionResult updateThongTinKhachHang(string personid, string hoten, int tuoi, int gioitinh, string sdt)
        {
            return RedirectToAction("QLUser");
        }

        [AdminOrNhanVienAuthentication]
        public IActionResult xoaKhachHang(string personid)
        {
            var orderphongs = repo.getOrderPhongByPerson(personid);
            var phongs = orderphongs.Select(o => o.MaPhongNavigation)
                .Select(p => {
                    p.MaTrangThai = "MTT1";
                    return p;
                });

            //khi xóa khách hàng xong thì những phòng mà khách hàng order phải xóa theo
            //mà khi order phòng bị xóa thì trạng thái phòng phải chuyển sang thành là "trống" (MTT1)IEnumerable<OrderPhong>           foreach (var orderphong in orderphongs)
            if(phongs != null) repo.updateTrangThaiPhongs(phongs); 

            repo.removeKhachHang(personid);

            return RedirectToAction("QLUser");
        }

        public IActionResult QLTaiKhoan()
        {
            LoaiTaiKhoan_TaiKhoan_NhanVien_KhacHang model = new LoaiTaiKhoan_TaiKhoan_NhanVien_KhacHang
            {
                loaiTaiKhoans = repo.getLoaiTaiKhoan,
                taikhoans = repo.getTaiKhoan,
                nhanviens = repo.getTaiKhoanNhanVien,
                khachhangs = repo.getTaiKhoanKhachHang
            };
            return View(model);
        }




        [HttpGet]
        [AdminAuthentication]
        [HttpPost]
        public IActionResult QLNhanVien(string manhanvien = null,
            string hoten = null,
            int tuoi = 0,
            int gioitinh = -1,
            string sdt = null,
            string vaitro = null,
            string username = null,
            string password = null
            , string confirm = null)
        {

            NhanVien_VaiTro model = new NhanVien_VaiTro
            {
                nhanviens = repo.getTaiKhoanNhanVien,
                vaitros = repo.GetVaiTros
            };
            if (password != confirm)
            {
                ModelState.AddModelError("", "Mật khẩu không giống");
            }

            if (repo.checkTonTaiUserName(username))
            {
                ModelState.AddModelError("", "Tài khoản đã tồn tại");
            }
            if (repo.checkTonTaiMaNhanVien(manhanvien))
            {
                ModelState.AddModelError("", "Mã nhân viên đã tồn tại");
            }

            if (manhanvien != null && hoten != null && tuoi > 0 && gioitinh != -1 && sdt != null && vaitro != null && username != null && password != null && confirm != null)
            {
                NhanVien nhanvien = new NhanVien
                {
                    NhanVienId = manhanvien,
                    MaVaiTro = vaitro,
                    NgayDuocTuyen = DateTime.Now,
                    NhanVienNavigation = new Person
                    {
                        PersonId = manhanvien,
                        HoTen = hoten,
                        Tuoi = tuoi,
                        GioiTinh = gioitinh,
                        Sdt = sdt
                    },
                };

                TaiKhoan taikhoan = new TaiKhoan
                {
                    MaTaiKhoan = repo.CreateMaTaiKhoan(),
                    UserName = username,
                    Password = password,
                    LoaiTaiKhoan = "LTK2",
                    PersonId = manhanvien,
                };

                if (repo.addNhanVien(nhanvien) && repo.addTaiKhoanNhanVien(taikhoan))
                {
                    ModelState.AddModelError("", "Tạo thành công");
                }

                else
                {
                    ModelState.AddModelError("", "Tạo thất bại");
                }
            }
            return View(model);
        }

    }

    public class LoaiPhongAndPhong
    {
        public List<LoaiPhong> lp { get; set; }
        public List<Phong> p { get; set; }
        public List<TrangThaiPhong> ttp { get; set; }
    }


    public class LoaiTaiKhoan_TaiKhoan_NhanVien_KhacHang
    {
        public IEnumerable<LoaiTaiKhoan> loaiTaiKhoans { get; set; }
        public IEnumerable<TaiKhoan> taikhoans { get; set; }
        public IEnumerable<NhanVien> nhanviens { get; set; }
        public IEnumerable<KhachHang> khachhangs { get; set; }
    }

    public class NhanVien_VaiTro
    {
        public IEnumerable<NhanVien> nhanviens { get; set; }
        public IEnumerable<VaiTro> vaitros { get; set; }
    }
}
