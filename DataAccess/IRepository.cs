using HotelManagement.Models;

namespace HotelManagement.DataAccess
{
    public interface IRepository
    {
        IEnumerable<Person> getPeople { get;  }

        void CreateAccount(TaiKhoan a);

        TaiKhoan CheckAccount(TaiKhoan a);

        string GetLastIndexOfPerson();

        string GetLastIndexOfAccount();

    }
}
