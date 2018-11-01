using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_DoPapukaija.Services;
using System.Web.Http;
using To_DoPapukaija.Models;
using System.Web.Http.Cors;
using System.Net;

namespace To_DoPapukaija.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {

        public LoginController()
        {
            _userService = new UserService();

        }

        private UserService _userService;
        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost] 
        public IHttpActionResult Authenticate(Kayttaja userParam)
        {
            var user = _userService.Authenticate(userParam.Email, userParam.Salasana);
            
            if(user == null)
            {
                return BadRequest(message: "Väärä käyttäjätunnus tai salasana");
            }
            
            return Content(HttpStatusCode.Created, user);
            
        }

        /*[HttpGet]
        public IHttpActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }*/
    }
}