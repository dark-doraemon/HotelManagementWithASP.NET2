using HotelManagement.Models;

namespace HotelManagement.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Person> getPeople { get; }

        bool CreateAccount(TaiKhoan a);

        TaiKhoan CheckAccount(TaiKhoan a);


        string GetLastIndexOfAccount();

        IEnumerable<LoaiPhong> getLoaiPhong { get; }

        IEnumerable<Phong> getPhongByLoaiPhong(string id);

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

        void updateTrangThaiPhong(string maphong, string maTrangThai);

        void addKhachHang(KhachHang kh);

        void addOrderPhong(OrderPhong orderPhong);

        void addOrderPhongDichVu(List<OrderPhongDichVu> orderphongdichvu);

        Phong getPhongByMaPhong(string id);


        IEnumerable<OrderPhong> getOrderPhongByMaPhong(string id);

        string createHoaDonId();

        void updateTrangThaiOrderPhong(string orderPhongId);
        //0 là chưa thanh toán
        //1 là đã thanh toán
        //2 là phòng đặt trước

        bool addHoaDon(HoaDon hoaDon);

        Person getPersonByUserName(string username);
    
        public IEnumerable<OrderPhong> getOrdrPhongByPerson(Person person);

        public int funcGetLastIndex(List<string> maid,int vt);

        public void removeOrderPhong(string maorder);

    }
}
