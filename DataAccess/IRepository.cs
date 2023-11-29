using HotelManagement.Models;

namespace HotelManagement.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Person> getPeople { get; }

        bool CreateAccount(TaiKhoan a);

        TaiKhoan CheckAccount(TaiKhoan a);


        string CreateMaTaiKhoan();

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
    
        public IEnumerable<OrderPhong> getOrderPhongByPerson(string personid);

        public int funcGetLastIndex(List<string> maid,int vt);

        public void removeOrderPhong(string maorder);

        IEnumerable<HoaDon> GetHoaDon { get; }

        IEnumerable<HoaDon> getChiTietHoaDon(string mahoadon);

        IEnumerable<KhachHang> getKhachHang { get; }

        public void removeKhachHang(string makhachhang);

        IEnumerable<LoaiTaiKhoan> getLoaiTaiKhoan {  get; }

        IEnumerable<TaiKhoan> getTaiKhoan { get; }

        IEnumerable<NhanVien> getTaiKhoanNhanVien { get; }

        IEnumerable<KhachHang> getTaiKhoanKhachHang { get; }

        IEnumerable<VaiTro> GetVaiTros { get; }

        bool checkTonTaiUserName(string username);


        bool checkTonTaiMaNhanVien(string manhanvien);
        
        bool addNhanVien(NhanVien nhanvien);

        bool addTaiKhoanNhanVien(TaiKhoan taiKhoan);

        void updateThongTinKhachHang(Person newperson);

        void updateTrangThaiPhongs(IEnumerable<Phong> phongs);

        IEnumerable<DichVu> getDichVus { get; }

        void updateDichVu(DichVu dichvu);

        bool xoaDichVu(string madichvu);

        bool themDichVu(DichVu dichvu);

        void updateThongTinNhanVien(Person nhanvien,NhanVien vaitro);

        void updateLoaiTaiKhoanOfPerson(string personID, string loaitaikhoan);

        bool removeNhanVien(string manhanvien);

        void updateLoaiTaiKhoan(LoaiTaiKhoan loaitaikhoancansua);

        bool updateTaiKhoan(string mataikhoan,string username, string password);
    }
}
