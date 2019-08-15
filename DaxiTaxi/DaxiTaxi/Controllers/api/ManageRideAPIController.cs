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
    public class ManageRideAPIController : ApiController
    {
        private TaxiAppContext _taxiContext;

        public ManageRideAPIController()
        {
            _taxiContext = new TaxiAppContext();
        }

        [HttpPut]
        [Route("api/managerideapi/acceptRide")]
        public IHttpActionResult AcceptRide(string id, string driverId)
        {
            int rideId = int.Parse(id);
            int driversId = int.Parse(driverId);

            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == rideId);
            var driver = (Driver)_taxiContext.Users.SingleOrDefault(r => r.Id == driversId);

            if (customersRide == null)
            {
                return BadRequest();
            }

            customersRide.RideState = ERideState.Processed;
            customersRide.Driver = driver;

            _taxiContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("api/managerideapi/rideSuccessful")]
        public IHttpActionResult RideSuccessful([FromUri]string id, [FromBody]Ride ride)
        {
            int rideId = int.Parse(id);

            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == rideId);

            if (customersRide == null)
            {
                return BadRequest();
            }

            int streetNum = int.Parse(ride.Destination.Address.StreetNumber.ToString());
            int callNum = int.Parse(ride.Destination.Address.CallNumber.ToString());

            Address destinationAddress = new Address
            {
                City = ride.Destination.Address.City,
                CallNumber = callNum,
                Street = ride.Destination.Address.Street,
                StreetNumber = streetNum
            };

            _taxiContext.Addresses.Add(destinationAddress);

            double xcoordinate = double.Parse(ride.Destination.XCoordinate.ToString());
            double ycoordinate = double.Parse(ride.Destination.YCoordinate.ToString());

            Location rideLocation = new Location
            {
                XCoordinate = xcoordinate,
                YCoordinate = ycoordinate,
                Address = destinationAddress
            };

            _taxiContext.Locations.Add(rideLocation);

            double amount = double.Parse(ride.Amount.ToString());

            customersRide.RideState = ERideState.Processed;
            customersRide.Destination = rideLocation;
            customersRide.Amount = amount;

            _taxiContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("api/managerideapi/rideUnsuccessful")]
        public IHttpActionResult RideUnsuccessful([FromUri]string id, [FromBody]Ride ride)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var Id = int.Parse(userId);

            if(userUsername == null || Id == 0)
            {
                return BadRequest();
            }

            var currentUser = _taxiContext.Users.Find(Id, userUsername);

            int rideId = int.Parse(id);
            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == rideId);

            if (customersRide == null)
            {
                return BadRequest();
            }

            DateTime current = DateTime.Now;

            Comment driversComment = new Comment
            {
                Description = ride.Comment.Description,
                PublishDate = current,
                UserThatLeftComment = currentUser,
                Rate = ride.Comment.Rate
            };

            _taxiContext.Comments.Add(driversComment);

            customersRide.RideState = ERideState.Processed;
            customersRide.Comment = driversComment;

            _taxiContext.SaveChanges();

            return Ok();
        }
    }
}
