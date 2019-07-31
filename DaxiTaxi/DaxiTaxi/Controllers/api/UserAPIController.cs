using DaxiTaxi.Context;
using DaxiTaxi.Models;
using DaxiTaxi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DaxiTaxi.Controllers.api
{
    public class UserAPIController : ApiController
    {
        private TaxiAppContext _taxiContext;

        public UserAPIController()
        {
            _taxiContext = new TaxiAppContext();
        }

        [HttpGet]
        public IEnumerable<User> Users()
        {
            return _taxiContext.Users.ToList();
        }


        [AllowAnonymous]
        [Route("api/userapi/login")]
        [HttpPost]
        public IHttpActionResult Login([FromBody]UserView data)
        {
            var loggedInUser = _taxiContext.Users.SingleOrDefault(u => u.Username == data.Username && u.Password == data.Password);

            if (loggedInUser != null)
            {
                var session = HttpContext.Current.Session;
                session["UserId"] = loggedInUser.Id.ToString();
                session["Username"] = loggedInUser.Username.ToString();
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost]
        [Route("api/userapi/register")]
        public Customer Register([FromBody]Customer customer)
        {

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _taxiContext.Users.Add(customer);
            _taxiContext.SaveChanges();

            return customer;
        }

        [HttpGet]
        [Route("api/userapi/loggedUser")]
        public IHttpActionResult GetLoggedInUser()
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);
            if (userUsername != null)
            {
                var currentUser = _taxiContext.Users.Find(id, userUsername);
                return Ok(currentUser);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("api/userapi/editProfile")]
        public void ChangeProfile([FromBody]User user)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            var currentUser = _taxiContext.Users.Find(id, userUsername);

            if (userUsername == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            currentUser.Username = user.Username;
            currentUser.Name = user.Name;
            currentUser.Surname = user.Surname;
            currentUser.Gender = user.Gender;
            currentUser.JMBG = user.JMBG;
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Email = user.Email;

            _taxiContext.SaveChanges();

        }


    }
}
