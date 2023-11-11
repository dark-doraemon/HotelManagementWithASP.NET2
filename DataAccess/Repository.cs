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

        public void CreateAccount(TaiKhoan a)
        {
            context.TaiKhoans.Add(a);
            context.SaveChanges();
        }
    }
}
