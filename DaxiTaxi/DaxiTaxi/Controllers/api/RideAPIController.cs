using DaxiTaxi.Context;
using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Data.Entity;

namespace DaxiTaxi.Controllers.api
{
    public class RideAPIController : ApiController
    {
        private TaxiAppContext _taxiContext;

        public RideAPIController()
        {
            _taxiContext = new TaxiAppContext();
        }

        [HttpGet]
        public IEnumerable<Ride> GetAllRides()
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            if (userUsername == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _taxiContext.Users.Find(id, userUsername);

            // Check logged in user role, method is available only for admins
            if (user.Role != ERole.ADMIN)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return _taxiContext.Rides.ToList();
        }

        /* ---- Get all customer rides with state Cretaed - On hold ---- */

        [HttpGet]
        [Route("api/rideapi/getCustomerRides")]
        public IEnumerable<Ride> GetCustomerRides()
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            if(id == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _taxiContext.Users.Find(id, userUsername);

            // Check logged in user role, method is available only for customer
            if (user.Role != ERole.CUSTOMER)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var rides = _taxiContext.Rides.Include("CustomerLocation").Include("CustomerLocation.Address").
                Include("Driver").Include("Dispatcher").Include("Comment").Include("Destination")
                .Where(r => r.Customer.Id == id).ToList();

            return rides;
        }

        /* ---- Get all rides with state Created - On hold ---- */

        [HttpGet]
        [Route("api/rideapi/getAllCreatedRides")]
        public IEnumerable<Ride> GetAllCreatedRides()
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            if(userUsername == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _taxiContext.Users.Find(id, userUsername);

            // Check logged in user role, method is available only for drivers
            if(user.Role != ERole.DRIVER)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return _taxiContext.Rides.Where(r => r.RideState == ERideState.Created).ToList();
        }

        [HttpGet]
        [Route("api/rideapi/getDriverRides")]
        public IEnumerable<Ride> GetDriverRides()
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            if (id == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _taxiContext.Users.Find(id, userUsername);

            // Check logged in user role, method is available only for drivers
            if (user.Role != ERole.DRIVER)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var rides = _taxiContext.Rides.Where(r => r.Driver.Id == id).ToList();

            return rides;
        }



        [HttpGet]
        [Route("api/rideapi/getAdminRides")]
        public IEnumerable<Ride> GetAdminRides()
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            if (id == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _taxiContext.Users.Find(id, userUsername);

            // Check logged in user role, method is available only for admins
            if (user.Role != ERole.ADMIN)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var rides = _taxiContext.Rides.Where(r => r.Dispatcher.Id == id).ToList();

            return rides;
        }
    }
}
