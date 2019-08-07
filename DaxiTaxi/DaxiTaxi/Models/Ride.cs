using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Ride
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDateTime { get; set; }

        [Required]
        public Location CustomerLocation { get; set; }

        public Customer Customer { get; set; }

        public Location Destination { get; set; }

        public Admin Dispatcher { get; set; }

        public Driver Driver { get; set; }

        public double Amount { get; set; }

        public Comment Comment { get; set; }

        [Required]
        public ERideState RideState { get; set; }
    }
}