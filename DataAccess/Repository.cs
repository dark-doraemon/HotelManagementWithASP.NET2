using HotelManagement.Models;
using System.Text.RegularExpressions;
using System.Transactions;

namespace HotelManagement.DataAccess
{
    public class Repository : IRepository
    {
        private HotelContext context;
        public Repository(HotelContext context)
        {

            this.context = context;
        }

        public IEnumerable<Person> getPeople => this.context.People;


        public TaiKhoan CheckAccount(TaiKhoan a)
        {
            var matchingAccount = this.context.TaiKhoans.FirstOrDefault(account => account.UserName == a.UserName && account.Password == a.Password);
            if (matchingAccount == null) return null;
            return matchingAccount;
        }

        public void CreateAccount(TaiKhoan a)
        {
            context.TaiKhoans.Add(a);
            context.SaveChanges();
        }

        public string GetLastIndexOfPerson()
        {
            return context.People.OrderByDescending(p => p.PersonId).FirstOrDefault().PersonId;
        }

        public string GetLastIndexOfAccount()
        {
            string lastId = context.TaiKhoans.OrderByDescending(a => a.MaTaiKhoan).FirstOrDefault().MaTaiKhoan;
            int number = int.Parse(Regex.Match(lastId, @"\d+").Value) + 1;
            return "TK" + number;
        }

        public IEnumerable<LoaiPhong> getLoaiPhong => context.LoaiPhongs;

        public IEnumerable<Phong> getPhong(string id)
        {
            if (id == null) return context.Phongs;
            return context.Phongs.Where(p => p.MaLoaiPhong == id);
        }

        public void removeLoaiPhong(string id)
        {
            //khi xóa loaiphong thì tất cả các phòng thuộc loại phòng đó đều bị xóa
            //do trong file context Phong có .Ondelete là cascade

            var loaiphong = context.LoaiPhongs.Where( lp => lp.MaLoaiPhong == id).FirstOrDefault();
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
            return context.Phongs.Where(p => p.MaTrangThai == trangthai);   
        }

        public IEnumerable<DichVu> getDichvu => context.DichVus;

        public string createOrderPhongId()
        {
            var orderPhong = context.OrderPhongs.OrderByDescending(o => o.MaOrderPhong).FirstOrDefault();
            string lastId;
            if (orderPhong == null) lastId = "0";
            else lastId = orderPhong.MaOrderPhong.ToString();
            int number = int.Parse(Regex.Match(lastId, @"\d+").Value) + 1;
            return "MOP" + number;
        }

        public void updateTrangThaiPhong(Phong phongCanUpdateTrangThai)
        {
            context.Update(phongCanUpdateTrangThai);
            context.SaveChanges();  
        }
    }
}
