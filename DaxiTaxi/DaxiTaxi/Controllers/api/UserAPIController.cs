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


        /* ---- Method for user login ---- */

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
                return Ok(loggedInUser);
            }
            else
                return NotFound();
        }

        /* ---- Register new customers ---- */

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

        /* ---- Get currently logged in user ---- */

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

        /* ---- Method for changing user profile ---- */

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
           // currentUser.Password = user.Password;

            _taxiContext.SaveChanges();

        }

        /* ---- Method for adding new drivers ---- */

        [HttpPost]
        [Route("api/userapi/addDrivers")]
        public Driver AddDrivers([FromBody]Driver driver)
        {

            if (driver == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var id = int.Parse(driver.Location.Id.ToString());
            var id2 = int.Parse(driver.Vehicle.Id.ToString());

            Location location = _taxiContext.Locations.SingleOrDefault(l => l.Id == id);
            Vehicle vehicle = _taxiContext.Vehicles.SingleOrDefault(l => l.Id == id2);

            var newDriver = new Driver();
            newDriver.Name = driver.Name;
            newDriver.Surname = driver.Surname;
            newDriver.Email = driver.Email;
            newDriver.Username = driver.Username;
            newDriver.Password = driver.Password;
            newDriver.PhoneNumber = driver.PhoneNumber;
            newDriver.JMBG = driver.Name;
            newDriver.Gender = driver.Gender;
            newDriver.Role = driver.Role;
            newDriver.Location = location;
            newDriver.Vehicle = vehicle;

            _taxiContext.Users.Add(newDriver);
            _taxiContext.SaveChanges();

            return driver;
        }

        /* --- Logout method --- */

        [HttpGet]
        [Route("api/userapi/logout")]
        public IHttpActionResult Logout()
        {
            HttpContext.Current.Session.Abandon();
            return Ok();
        }
    }
}
