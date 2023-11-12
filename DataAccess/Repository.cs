//using HotelManagement.Models;

using HotelManagement.Models;
using System.Text.RegularExpressions;

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
            var matchingAccount = this.context.TaiKhoans.FirstOrDefault(account => account.UserName == a.UserName && account.Password == a.Password);
            if (matchingAccount == null) return false;
            return true;
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
            return "TK" + number ;
        }

    }
}
