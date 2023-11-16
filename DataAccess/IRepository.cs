using HotelManagement.Models;

namespace HotelManagement.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Person> getPeople { get; }

        void CreateAccount(TaiKhoan a);

        TaiKhoan CheckAccount(TaiKhoan a);

        string GetLastIndexOfPerson();

        string GetLastIndexOfAccount();

        IEnumerable<LoaiPhong> getLoaiPhong { get; }

        IEnumerable<Phong> getPhong(string id);

        void removeLoaiPhong(string id);

        void themLoaiPhong(LoaiPhong newloaiphong);

        void suaLoaiPhong(LoaiPhong phongcuasua);

        public IEnumerable<TrangThaiPhong> getTrangThaiPhong { get; }

        void themPhong(Phong newphong);

        void xoaPhong(string id);

        void suaPhong(Phong phongcansua);

        public IEnumerable<Phong> getPhongByMaTrangThai(string trangthai);    

        public IEnumerable<DichVu> getDichvu { get; }

        string createOrderPhongId();

        void updateTrangThaiPhong(string maphong,string maTrangThai);

        void addKhachHang(KhachHang kh);

        void addOrderPhong(OrderPhong orderPhong);

        void addOrderPhongDichVu(List<OrderPhongDichVu> orderphongdichvu);
    }
}
