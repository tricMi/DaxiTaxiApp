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

        /* --- Process ride option available for admins --- */

        [HttpPut]
        [Route("api/managerideapi/processRide")]
        public IHttpActionResult ProcessRide(string id, string driverId)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var uId = int.Parse(userId);

            if (userUsername == null || uId == 0)
            {
                return BadRequest();
            }

            var currentUser = _taxiContext.Users.Find(uId, userUsername);

            if(currentUser.Role != ERole.ADMIN)
            {
                return BadRequest();
            }

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
        [Route("api/managerideapi/acceptRide")]
        public IHttpActionResult AcceptRide(string id)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var uId = int.Parse(userId);

            if(userUsername == null || uId == 0)
            {
                return BadRequest();
            }

            var currentUser = (Driver)_taxiContext.Users.Find(uId, userUsername);


            int rideId = int.Parse(id);
            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == rideId);

            customersRide.RideState = ERideState.Accepted;
            customersRide.Driver = currentUser;

            _taxiContext.SaveChanges();

            return Ok();
        }

        /* --- Customer cancel ride option --- */

        [HttpPut]
        [Route("api/managerideapi/cancelRide")]
        public IHttpActionResult CancelRide([FromUri]string id, [FromBody]Ride ride)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var uId = int.Parse(userId);

            if(userUsername == null || uId == 0)
            {
                return BadRequest();
            }

            var currentUser = (Customer)_taxiContext.Users.Find(uId, userUsername);

            int Id = int.Parse(id);

            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == Id);

            if (customersRide == null)
            {
                return BadRequest();
            }

            DateTime current = DateTime.Now;
            var rate = int.Parse(ride.Comment.Rate.ToString());

            Comment customersComment = new Comment
            {
                Description = ride.Comment.Description,
                PublishDate = current,
                UserThatLeftComment = currentUser,
                Rate = rate
            };

            _taxiContext.Comments.Add(customersComment);

            customersRide.RideState = ERideState.Canceled;
            customersRide.Comment = customersComment;

            _taxiContext.SaveChanges();

            return Ok();
        }

        /* --- Successful ride state change method with updated destination and cost fields --- */

        [HttpPut]
        [Route("api/managerideapi/rideSuccessful")]
        public IHttpActionResult RideSuccessful([FromUri]string id, [FromBody]Ride ride)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var IdUser = int.Parse(userId);

            if (userUsername == null || IdUser == 0)
            {
                return BadRequest();
            }

            var currentUser = _taxiContext.Users.Find(IdUser, userUsername);

            if (currentUser.Role != ERole.DRIVER)
            {
                return BadRequest();
            }

            //Parse ride id
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

            customersRide.RideState = ERideState.Successful;
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

            if(currentUser.Role != ERole.DRIVER)
            {
                return BadRequest();
            }

            int rideId = int.Parse(id);
            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == rideId);

            if (customersRide == null)
            {
                return BadRequest();
            }

            DateTime current = DateTime.Now;
            var rate = int.Parse(ride.Comment.Rate.ToString());

            Comment driversComment = new Comment
            {
                Description = ride.Comment.Description,
                PublishDate = current,
                UserThatLeftComment = currentUser,
                Rate = rate
            };

            _taxiContext.Comments.Add(driversComment);

            customersRide.RideState = ERideState.Unsuccessful;
            customersRide.Comment = driversComment;

            _taxiContext.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Route("api/managerideapi/leaveComment")]
        public IHttpActionResult LeaveComment([FromUri]string id, [FromBody]Ride ride)
        {
            var userUsername = HttpContext.Current.Session["Username"].ToString();
            var userId = HttpContext.Current.Session["UserId"].ToString();
            var uId = int.Parse(userId);

            if(userUsername == null)
            {
                return BadRequest();
            }

            var currentUser = _taxiContext.Users.Find(uId, userUsername);

            DateTime current = DateTime.Now;
            var rate = int.Parse(ride.Comment.Rate.ToString());

            Comment customerComment = new Comment
            {
                Description = ride.Comment.Description,
                PublishDate = current,
                UserThatLeftComment = currentUser,
                Rate = rate
            };

            _taxiContext.Comments.Add(customerComment);

            int rideId = int.Parse(id);
            var customersRide = _taxiContext.Rides.SingleOrDefault(r => r.Id == rideId);

            customersRide.Comment = customerComment;

            _taxiContext.SaveChanges();

            return Ok();
        }
    }
}
