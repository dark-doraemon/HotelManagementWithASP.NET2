using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Transactions;

namespace HotelManagement.DataAccess
{
    public class Repository : IRepository
    {
        private HotelContext context;
        private IHttpContextAccessor accessor;
        public Repository(HotelContext context, IHttpContextAccessor accessor)
        {

            this.context = context;
            this.accessor = accessor;
        }

        public IEnumerable<Person> getPeople => this.context.People;


        public TaiKhoan CheckAccount(TaiKhoan a)
        {
            var matchingAccount = this.context.TaiKhoans.FirstOrDefault(account => account.UserName == a.UserName && account.Password == a.Password);
            if (matchingAccount == null) return null;
            return matchingAccount;
        }

        public bool CreateAccount(TaiKhoan a)
        {
            var checkTrungUserName = context.TaiKhoans.Where(account => account.UserName == a.UserName).Any();
            if (checkTrungUserName)//nếu có return false
            {
                return false;
            }
            else
            {
                context.TaiKhoans.Add(a);
                var check = context.SaveChanges();
                if (check > 0)
                {
                    context.KhachHangs.Add(new KhachHang { KhachHangId = a.PersonId });
                    context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
        }

        public string CreateMaTaiKhoan()
        {
            if (context.TaiKhoans.Any() == false)
            {
                return "TK1";
            }
            List<string> maTaiKhoan = context.TaiKhoans.Select(tk => tk.MaTaiKhoan).ToList();
            int lasId = funcGetLastIndex(maTaiKhoan, 2) + 1;
            return "TK" + lasId;
        }

        public IEnumerable<LoaiPhong> getLoaiPhong => context.LoaiPhongs;

        public IEnumerable<Phong> getPhongByLoaiPhong(string id)
        {
            if (id == null)
            {
                var s1 = context.Phongs;
                var s2 = s1
                    .Include(p => p.OrderPhongs.Where(od => od.TrangThaiThanhToan == 0))
                    .ThenInclude(od => od.Person)
                    .Include(p => p.OrderPhongs.Where(od => od.TrangThaiThanhToan == 0))
                    .ThenInclude(od => od.OrderPhongDichVus)
                    .ThenInclude(odpdv => odpdv.MaDichVuNavigation);
                return s2;
            }
            var s3 = context.Phongs.Where(p => p.MaLoaiPhong == id);
            var s4 = s3
                .Include(p => p.OrderPhongs.Where(od => od.TrangThaiThanhToan == 0))
                .ThenInclude(od => od.Person)
                .Include(p => p.OrderPhongs.Where(od => od.TrangThaiThanhToan == 0))
                .ThenInclude(od => od.OrderPhongDichVus)
                .ThenInclude(odpdv => odpdv.MaDichVuNavigation);
            return s4;
        }

        public void removeLoaiPhong(string id)
        {
            //khi xóa loaiphong thì tất cả các phòng thuộc loại phòng đó đều bị xóa
            //do trong file context Phong có .Ondelete là cascade

            var loaiphong = context.LoaiPhongs.Where(lp => lp.MaLoaiPhong == id).FirstOrDefault();
            context.Remove(loaiphong);
            context.SaveChanges();
        }

        public void themLoaiPhong(LoaiPhong newloaiphong)
        {
            context.LoaiPhongs.Add(newloaiphong);
            context.SaveChanges();
        }

        public void suaLoaiPhong(LoaiPhong phongcuasua)
        {
            context.Update(phongcuasua);
            context.SaveChanges();
        }

        public IEnumerable<TrangThaiPhong> getTrangThaiPhong => context.TrangThaiPhongs;


        public void themPhong(Phong newphong)
        {
            context.Phongs.Add(newphong);
            context.SaveChanges();
        }

        public void xoaPhong(string id)
        {
            context.Phongs.Remove(context.Phongs.Where(p => p.MaPhong == id).FirstOrDefault());
            context.SaveChanges();
        }

        public void suaPhong(Phong phongcansua)
        {
            context.Phongs.Update(phongcansua);
            context.SaveChanges();
        }

        public IEnumerable<Phong> getPhongByMaTrangThai(string trangthai)
        {
            return context.Phongs.Where(p => p.MaTrangThai == trangthai)
                .Include(p => p.OrderPhongs.Where(od => od.TrangThaiThanhToan == 0))
                .ThenInclude(od => od.Person)
                .Include(p => p.OrderPhongs.Where(od => od.TrangThaiThanhToan == 0))
                .ThenInclude(od => od.OrderPhongDichVus)
                .ThenInclude(odpdv => odpdv.MaDichVuNavigation);
        }

        public IEnumerable<DichVu> getDichvu => context.DichVus;


        public string createOrderPhongId()
        {
            bool check = context.OrderPhongs.Any();
            if (check == false)
            {
                return "MOP1";
            }

            var maOrderPhongs = context.OrderPhongs.Select(o => o.MaOrderPhong).ToList();
            int lastIndex = funcGetLastIndex(maOrderPhongs, 3) + 1;
            return "MOP" + lastIndex;

        }

        public void updateTrangThaiPhong(string maphong, string maTrangThai)
        {
            Phong phongCanSuaTrangThai = context.Phongs.Where(p => p.MaPhong == maphong).FirstOrDefault();
            phongCanSuaTrangThai.MaTrangThai = maTrangThai;
            context.Phongs.Update(phongCanSuaTrangThai);
            context.SaveChanges();
        }

        public void addKhachHang(KhachHang kh)
        {
            if (context.KhachHangs.Find(kh.KhachHangId) == null)
            {
                context.KhachHangs.Add(kh);
                context.SaveChanges();
            }
        }


        public void addOrderPhong(OrderPhong orderPhong)
        {
            if (context.People.Where(p => p.PersonId == orderPhong.PersonId).Any())
            {
                context.People.Update(orderPhong.Person);
                context.SaveChanges();
            }
            //khi add orderPhong thi thông tin người order cũng được lưu tại vì trong orderPhong có Person 
            context.OrderPhongs.Add(orderPhong);
            context.SaveChanges();

            KhachHang kh = new KhachHang
            {
                KhachHangId = orderPhong.PersonId,
            };
            //nếu người đặt phòng không phải là user
            if (accessor.HttpContext.Session.GetString("UserName") == null)
            {
                addKhachHang(kh);
            }

        }

        public void addOrderPhongDichVu(List<OrderPhongDichVu> orderphongdichvu)
        {
            context.OrderPhongDichVus.AddRange(orderphongdichvu);
            context.SaveChanges();
        }
        public Phong getPhongByMaPhong(string id)
        {
            return context.Phongs.Where(p => p.MaPhong == id).FirstOrDefault();
        }


        public IEnumerable<OrderPhong> getOrderPhongByMaPhong(string id)
        {
            if (id == null)
            {
                return context.OrderPhongs.
                    Include(o => o.Person).
                    Include(o => o.MaPhongNavigation).ThenInclude(p => p.MaLoaiPhongNavigation).
                    Include(o => o.OrderPhongDichVus).
                    ThenInclude(od => od.MaDichVuNavigation);
            }

            else
            {
                return context.OrderPhongs.
                    Where(o => o.MaPhong == id).
                    Include(o => o.Person).
                    Include(o => o.MaPhongNavigation).ThenInclude(p => p.MaLoaiPhongNavigation).
                    Include(o => o.OrderPhongDichVus).
                    ThenInclude(od => od.MaDichVuNavigation);
            }

        }

        public string createHoaDonId()
        {
            if (context.HoaDons.Any() == false) return "HD1";
            List<string> maHoaDon = context.HoaDons.Select(hd => hd.MaHoaDon).ToList();
            int lastId = funcGetLastIndex(maHoaDon, 2) + 1;
            return "HD" + lastId;
        }

        public bool addHoaDon(HoaDon hoaDon)
        {
            var check = context.HoaDons.Where(hd => hd.MaOrderPhong == hoaDon.MaOrderPhong).Any();
            if (check) return false;
            else
            {
                context.HoaDons.Add(hoaDon);
                var checkSave = context.SaveChanges();
                if (checkSave != 0) return true;
                else return false;
            }
        }

        public void updateTrangThaiOrderPhong(string orderPhongId)
        {
            OrderPhong od = context.OrderPhongs.FirstOrDefault(od => od.MaOrderPhong == orderPhongId);
            od.TrangThaiThanhToan = 1; // cập nhật lại là đã thanh toán
            context.OrderPhongs.Update(od);
            context.SaveChanges();

        }

        public Person getPersonByUserName(string username)
        {
            //C1 :
            //đầu tiền cần xác định userName này của tài khoản nào
            TaiKhoan taiKhoan = context.TaiKhoans.FirstOrDefault(tk => tk.UserName == username);

            //tiếp theo từ tài khoản lấy ra PersonId;
            string personId = taiKhoan.PersonId;

            //cuối cùng lấy Person dự trên PersonId
            return context.People.FirstOrDefault(p => p.PersonId == personId);

            ////C2 : từ toài khoản lấy luôn person bằng EF
            //var tk = context.TaiKhoans.Where(tk => tk.UserName == username).
            //    Include( tk => tk.Person).FirstOrDefault();
            //return tk.Person;
        }

        public IEnumerable<OrderPhong> getOrderPhongByPerson(string personid)
        {
            var result = context.OrderPhongs.
                Include(od => od.MaPhongNavigation).
                Where(od => od.PersonId == personid && od.TrangThaiThanhToan == 0);
            return result;
        }

        public int funcGetLastIndex(List<string> maid, int vt)
        {
            List<int> STT = maid.Select(ma => int.TryParse(ma.Substring(vt), out int number) ? number : -1).Where(number => number != -1).ToList();
            STT.Sort();
            return STT[STT.Count - 1];
        }

        public void removeOrderPhong(string maorder)
        {
            OrderPhong order = context.OrderPhongs.FirstOrDefault(od => od.MaOrderPhong == maorder);
            context.OrderPhongs.Remove(order);
            context.SaveChanges();
        }

        public IEnumerable<HoaDon> GetHoaDon => context.HoaDons.Include(hd => hd.MaOrderPhongNavigation);

        public IEnumerable<HoaDon> getChiTietHoaDon(string mahoadon)
        {
            var hoadon = context.HoaDons.Where(hd => hd.MaHoaDon == mahoadon);
            return hoadon.Include(hd => hd.MaOrderPhongNavigation)
                         .ThenInclude(od => od.MaPhongNavigation)
                         .ThenInclude(od => od.MaLoaiPhongNavigation)
                         .Include(hd => hd.MaOrderPhongNavigation)
                         .ThenInclude(od => od.OrderPhongDichVus)
                         .ThenInclude(odpdv => odpdv.MaDichVuNavigation)
                         .Include(hd => hd.MaOrderPhongNavigation)
                         .ThenInclude(od => od.Person);
        }

        public IEnumerable<KhachHang> getKhachHang => context.KhachHangs.Include(kh => kh.KhachHangNavigation)
                                                                        .ThenInclude(p => p.OrderPhongs);

        public void removeKhachHang(string makhachhang)
        {
            Person person = context.People.Where(p => p.PersonId == makhachhang).FirstOrDefault();
            context.People.Remove(person);
            context.SaveChanges();
        }


        public IEnumerable<LoaiTaiKhoan> getLoaiTaiKhoan => context.LoaiTaiKhoans;

        public IEnumerable<TaiKhoan> getTaiKhoan => context.TaiKhoans;

        public IEnumerable<NhanVien> getTaiKhoanNhanVien => context.NhanViens
            .Include(nv => nv.MaVaiTroNavigation)
            .Include(nv => nv.NhanVienNavigation)
            .ThenInclude(p => p.TaiKhoans);

        public IEnumerable<KhachHang> getTaiKhoanKhachHang => context.KhachHangs
            .Include(kh => kh.KhachHangNavigation)
            .ThenInclude(p => p.TaiKhoans);

        public IEnumerable<VaiTro> GetVaiTros => context.VaiTros;

        public bool checkTonTaiUserName(string username)
        {
            bool check = context.TaiKhoans.Where(tk => tk.UserName == username).Any();
            if (check) return true;
            return false;
        }

        public bool checkTonTaiMaNhanVien(string manhanvien)
        {
            bool check = context.NhanViens.Where(nv => nv.NhanVienId == manhanvien).Any();
            if (check) return true;
            return false;

        }

        public bool addNhanVien(NhanVien nhanvien)
        {
            //khi add nhan vien thi person cũng add theo 
            context.NhanViens.Add(nhanvien);
            int check = context.SaveChanges();
            if (check > 0) return true;
            return false;
        }

        public bool addTaiKhoanNhanVien(TaiKhoan taiKhoan)
        {
            context.TaiKhoans.Add(taiKhoan);
            int check = context.SaveChanges();
            if (check > 0) return true;
            return false;
        }

        public void updateTrangThaiPhongs(IEnumerable<Phong> phongs)
        {
            context.Phongs.UpdateRange(phongs);
            context.SaveChanges();
        }


        public void updateThongTinKhachHang(Person newperson)
        {


            context.People.Update(newperson);
            context.SaveChanges();
        }

        public IEnumerable<DichVu> getDichVus => context.DichVus;


        public void updateDichVu(DichVu dichvu)
        {
            context.DichVus.Update(dichvu);
            context.SaveChanges();
        }

        public bool xoaDichVu(string madichvu)
        {
            DichVu dichvu = context.DichVus.FirstOrDefault(dv => dv.MaDichVu == madichvu);
            if (dichvu == null) return false;
            else
            {
                context.DichVus.Remove(dichvu);
                context.SaveChanges();
                return true;
            }
        }

        public bool themDichVu(DichVu dichvu)
        {
            var dv = context.DichVus.FirstOrDefault(dv => dv.MaDichVu == dichvu.MaDichVu);
            if (dv != null)
            {
                return false;
            }
            else
            {
                context.DichVus.Add(dichvu);
                context.SaveChanges();
                return true;
            }
        }


        public void updateThongTinNhanVien(Person nhanvien, NhanVien vaitro)
        {
            context.People.Update(nhanvien);
            context.NhanViens.Update(vaitro);
            context.SaveChanges();
        }

        public void updateLoaiTaiKhoanOfPerson(string personID, string loaitaikhoan)
        {
            var taikhoan = context.TaiKhoans.Where(tk => tk.PersonId == personID).ToList()
                .Select(tk =>
                {
                    tk.LoaiTaiKhoan = loaitaikhoan;
                    return tk;
                });


            context.TaiKhoans.UpdateRange(taikhoan);
            context.SaveChanges();

        }
        public bool removeNhanVien(string manhanvien)
        {
            Person nhanvien = context.People.FirstOrDefault(p => p.PersonId == manhanvien);
            if (nhanvien == null) {
                return false;
            }
            else
            {
                context.People.Remove(nhanvien);
                context.SaveChanges() ;
                return true;
            }
        }

        public void updateLoaiTaiKhoan(LoaiTaiKhoan loaitaikhoancansua)
        {
            context.LoaiTaiKhoans.Update(loaitaikhoancansua);
            context.SaveChanges() ; 
        }

        public bool updateTaiKhoan(string mataikhoan,string username, string password)
        {
            TaiKhoan check = context.TaiKhoans.FirstOrDefault(tk => tk.MaTaiKhoan == mataikhoan);
            if (check == null)
            {
                return false;
            }
            else
            {
                check.UserName = username;
                check.Password = password;
                context.TaiKhoans.Update(check);
                context.SaveChanges() ;
                return true;
            }
        }


    }
}
