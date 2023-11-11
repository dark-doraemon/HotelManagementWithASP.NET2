//using HotelManagement.Models;

using HotelManagement.Models;

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

        public bool CheckAccount(TaiKhoan a)
        {
           var s = this.context.TaiKhoans.Where(account => account.UserName == a.UserName && account.Password == a.Password);
            if (s.Count() == 0) return false;
            return true;
        }

        public void CreateAccount(TaiKhoan a)
        {
            context.TaiKhoans.Add(a);
            context.SaveChanges();
        }
    }
}
