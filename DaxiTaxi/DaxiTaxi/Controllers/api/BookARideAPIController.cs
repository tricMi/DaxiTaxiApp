using DaxiTaxi.Context;
using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DaxiTaxi.Controllers.api
{
    public class BookARideAPIController : ApiController
    {
        private TaxiAppContext _taxiContext;

        public BookARideAPIController()
        {
            _taxiContext = new TaxiAppContext();
        }

        /* --- Method that allows customers to book a ride --- */

        [HttpPost]
        [Route("api/bookarideapi/bookride")]
        public Ride BookARide([FromBody]Ride ride)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            var currentUser = (Customer)_taxiContext.Users.Find(id, userUsername);

            if (ride == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            /* --- Add selected address --- */

            int streetNum = int.Parse(ride.CustomerLocation.Address.StreetNumber.ToString());

            Address currentAddress = new Address
            {
                City = ride.CustomerLocation.Address.City,
                CallNumber = ride.CustomerLocation.Address.CallNumber,
                Street = ride.CustomerLocation.Address.Street,
                StreetNumber = streetNum
            };

            _taxiContext.Addresses.Add(currentAddress);

            /* --- Add selected location */

            double xcoordinate = double.Parse(ride.CustomerLocation.XCoordinate.ToString());
            double ycoordinate = double.Parse(ride.CustomerLocation.YCoordinate.ToString());

            Location currentLocation = new Location
            {
                XCoordinate = xcoordinate,
                YCoordinate = ycoordinate,
                Address = currentAddress
            };

            _taxiContext.Locations.Add(currentLocation);

            /* --- Add ride --- */

            DateTime now = DateTime.Now;

            Ride createdRide = new Ride
            {
                RideState = ERideState.Created,
                Customer = currentUser,
                OrderDateTime = now,
                CustomerLocation = currentLocation
            };

            _taxiContext.Rides.Add(createdRide);

            _taxiContext.SaveChanges();

            return ride;
        }

        /* --- Method for forming rides, available for admins */

        [HttpPost]
        [Route("api/bookarideapi/formride")]
        public Ride FormARide([FromBody]Ride ride)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            var currentUser = (Admin)_taxiContext.Users.Find(id, userUsername);

            if (ride == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            /* --- Add selected address --- */

            int streetNum = int.Parse(ride.CustomerLocation.Address.StreetNumber.ToString());

            Address currentAddress = new Address
            {
                City = ride.CustomerLocation.Address.City,
                CallNumber = ride.CustomerLocation.Address.CallNumber,
                Street = ride.CustomerLocation.Address.Street,
                StreetNumber = streetNum
            };

            _taxiContext.Addresses.Add(currentAddress);

            /* --- Add selected location */

            double xcoordinate = double.Parse(ride.CustomerLocation.XCoordinate.ToString());
            double ycoordinate = double.Parse(ride.CustomerLocation.YCoordinate.ToString());

            Location currentLocation = new Location
            {
                XCoordinate = xcoordinate,
                YCoordinate = ycoordinate,
                Address = currentAddress
            };

            _taxiContext.Locations.Add(currentLocation);

            /* --- Add ride --- */

            DateTime now = DateTime.Now;
            int driverId = int.Parse(ride.Driver.Id.ToString());
            var driver = (Driver)_taxiContext.Users.SingleOrDefault(d => d.Id == driverId);

            Ride formedRide = new Ride
            {
                RideState = ERideState.Formed,
                Dispatcher = currentUser,
                OrderDateTime = now,
                CustomerLocation = currentLocation,
                Driver = driver
            };

            _taxiContext.Rides.Add(formedRide);

            _taxiContext.SaveChanges();

            return ride;
        }
    }
}
