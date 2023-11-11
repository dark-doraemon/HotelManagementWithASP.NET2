using HotelManagement.Models;

namespace HotelManagement.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Person> getPeople { get;  }

        void CreateAccount(TaiKhoan a);

        bool CheckAccount(TaiKhoan a);
    }
}
