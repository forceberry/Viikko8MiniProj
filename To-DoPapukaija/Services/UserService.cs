using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_DoPapukaija.Helpers;
using To_DoPapukaija.Models;

namespace To_DoPapukaija.Services
{
    public interface IUserService
    {
        Kayttaja Authenticate(string username, string password);
        IEnumerable<Kayttaja> GetAll();
    }
    public class UserService : IUserService
    {
        private List<Kayttaja> _users = new List<Kayttaja>
        {
            new Kayttaja { ID = 1, Etunimi = "Test", Sukunimi = "User", Email = "test", Salasana = "test" }
        }; // tähän listaan pitää tuoda DB käyttäjät

       public Kayttaja Authenticate(string email, string salasana)
        {
            var user = _users.SingleOrDefault(x => x.Email == email && x.Salasana == salasana);

            if(user == null)
            {
                return null;
            }

            return user;
        }

        public IEnumerable<Kayttaja> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Salasana = null;
                return x;
            });
        }
    }
}