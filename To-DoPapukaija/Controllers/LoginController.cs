using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_DoPapukaija.Services;
using System.Web.Http;
using To_DoPapukaija.Models;

namespace To_DoPapukaija.Controllers
{

    public class LoginController : ApiController
    {
        private IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost] //saattaa olla väärä
        public IHttpActionResult Authenticate(Kayttaja userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Salasana);
            
            if(user == null)
            {
                return BadRequest(message: "Väärä käyttäjätunnus tai salasana");
            }

            return Ok(user);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}