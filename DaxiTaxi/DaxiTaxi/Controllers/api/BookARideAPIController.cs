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

        [HttpPost]
        [Route("api/bookarideapi/bookride")]
        public Ride BookARide([FromBody]Ride ride)
        {
            if(ride == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var id = int.Parse(userId);

            var currentUser = (Customer)_taxiContext.Users.Find(id, userUsername);

            int streetNum = int.Parse(ride.CustomerLocation.Address.StreetNumber.ToString());

            Address a = new Address();
            a.City = ride.CustomerLocation.Address.City;
            a.CallNumber = ride.CustomerLocation.Address.CallNumber;
            a.Street = ride.CustomerLocation.Address.Street;
            a.StreetNumber = streetNum;

            _taxiContext.Addresses.Add(a);

            double xcoordinate = double.Parse(ride.CustomerLocation.XCoordinate.ToString());
            double ycoordinate = double.Parse(ride.CustomerLocation.YCoordinate.ToString());

            Location l = new Location();
            l.XCoordinate = xcoordinate;
            l.YCoordinate = ycoordinate;
            l.Address = a;

            _taxiContext.Locations.Add(l);

            DateTime now = DateTime.Now;

            Ride r = new Ride();
            r.RideState = ERideState.Created;
            r.Customer = currentUser;
            r.OrderDateTime = now;
            r.CustomerLocation = l;

            _taxiContext.Rides.Add(r);

            _taxiContext.SaveChanges();

            return ride;
        }
    }
}
