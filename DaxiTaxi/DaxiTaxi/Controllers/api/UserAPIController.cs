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


        
    }
}
