using DaxiTaxi.Context;
using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
