using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_DoPapukaija.Controllers;
using To_DoPapukaija.Helpers;
using To_DoPapukaija.Models;

namespace To_DoPapukaija.Services
{
 
    public class UserService
    {
       

       public Kayttaja Authenticate(string email, string salasana)
        {
            KayttajatController kc = new KayttajatController();
            var user = kc.db.Kayttaja.SingleOrDefault(x => x.Email == email && x.Salasana == salasana);

            if(user == null)
            {
                return null;
            }

            return user;
        }

      
    }
}