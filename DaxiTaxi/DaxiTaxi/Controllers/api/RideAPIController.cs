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
using System.Device.Location;

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

            return _taxiContext.Rides.Include("CustomerLocation").Include("Dispatcher").Include("CustomerLocation.Address").Include("Driver").
                        Include("Customer").Include("Comment").Include("Destination").Include("Destination.Address").ToList();
        }

        /* ---- Get all customer rides ---- */

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
                Include("Driver").Include("Dispatcher").Include("Comment").Include("Destination").Include("Destination.Address")
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

            return _taxiContext.Rides.Include("CustomerLocation").Include("CustomerLocation.Address").
                        Include("Driver").Include("Customer").Include("Comment").Include("Destination").
                        Include("Dispatcher").Include("Destination.Address").
                            Where(r => r.RideState == ERideState.Created).ToList();
        }

        /* --- Get all driver rides --- */

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

            var rides = _taxiContext.Rides.Include("CustomerLocation").Include("CustomerLocation.Address").
                            Include("Dispatcher").Include("Customer").Include("Comment").Include("Destination").Include("Destination.Address").
                                Where(r => r.Driver.Id == id).ToList();

            return rides;
        }

        /* --- Get all rides formed by dispatcher --- */

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

            var rides = _taxiContext.Rides.Include("CustomerLocation").Include("CustomerLocation.Address").
                            Include("Driver").Include("Customer").Include("Comment").Include("Destination").Include("Destination.Address").
                                Where(r => r.Dispatcher.Id == id).ToList();

            return rides;
        }

        /* --- Get a single ride item --- */

        [HttpGet]
        [Route("api/rideapi/getRide")]
        public Ride GetRide(string Id)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var idUser = int.Parse(userId);

            if (userUsername == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var id = int.Parse(Id);
            var ride = _taxiContext.Rides.Include("CustomerLocation").
                Include("CustomerLocation.Address").Include("Customer").Include("Dispatcher").
                Include("Driver").Include("Comment").Include("Destination").Include("Destination.Address").
                SingleOrDefault(r => r.Id == id);

            if(ride == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            return ride;
        }

        

        /* --- Method that returns only available drivers --- */

        [HttpGet]
        [Route("api/rideapi/available")]
        public IEnumerable<Driver> GetAvailableDrivers(string id)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var idUser = int.Parse(userId);

            if(userUsername == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var user = _taxiContext.Users.Find(idUser, userUsername);

            if(user.Role != ERole.ADMIN)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }


            int Id = int.Parse(id);

            var rides = _taxiContext.Rides.Include("CustomerLocation").SingleOrDefault(r => r.Id == Id);

            var availableDrivers = new List<Driver>();

            if(rides != null && rides.CustomerLocation != null) {

                //Showing only 5 nearest available drivers based on customers location
                availableDrivers = _taxiContext.Users.OfType<Driver>().Include("Location").
                Where(v => v.Role == ERole.DRIVER).
                Where(d => !_taxiContext.Rides.Any(r => r.Driver.Id == d.Id && r.RideState != ERideState.Successful)).Take(5).
                OrderBy(x => Math.Pow((rides.CustomerLocation.XCoordinate - x.Location.XCoordinate), 2) +
                Math.Pow((rides.CustomerLocation.YCoordinate - x.Location.YCoordinate), 2)).ToList();

            }

            else if(Id == 0 || rides.CustomerLocation == null)
            {
                availableDrivers = _taxiContext.Users.OfType<Driver>().Include("Location").
                Where(v => v.Role == ERole.DRIVER).
                Where(d => !_taxiContext.Rides.Any(r => r.Driver.Id == d.Id && r.RideState != ERideState.Successful)).ToList();
            }
   

            return availableDrivers;
        }
    }
}
