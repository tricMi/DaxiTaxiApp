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
            currentUser.Password = user.Password;

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

            var idVehicle = int.Parse(driver.Vehicle.Id.ToString());

            int streetNum = int.Parse(driver.Location.Address.StreetNumber.ToString());
            int callNum = int.Parse(driver.Location.Address.CallNumber.ToString());

            Address locationAddress = new Address
            {
                City = driver.Location.Address.City,
                CallNumber = callNum,
                Street = driver.Location.Address.Street,
                StreetNumber = streetNum
            };

            _taxiContext.Addresses.Add(locationAddress);

            double xcoordinate = double.Parse(driver.Location.XCoordinate.ToString());
            double ycoordinate = double.Parse(driver.Location.YCoordinate.ToString());

            Location driverLocation = new Location
            {
                XCoordinate = xcoordinate,
                YCoordinate = ycoordinate,
                Address = locationAddress
            };

            _taxiContext.Locations.Add(driverLocation);

            Vehicle vehicle = _taxiContext.Vehicles.SingleOrDefault(l => l.Id == idVehicle);

            var newDriver = new Driver
            {
                Name = driver.Name,
                Surname = driver.Surname,
                Email = driver.Email,
                Username = driver.Username,
                Password = driver.Password,
                PhoneNumber = driver.PhoneNumber,
                JMBG = driver.JMBG,
                Gender = driver.Gender,
                Role = driver.Role,
                Location = driverLocation,
                Vehicle = vehicle,
            };

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
