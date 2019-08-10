using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        [Display(Name = "Order Date")]
        public DateTime OrderDateTime { get; set; }

        [Required]
        [Display(Name = "Current Location")]
        public Location CustomerLocation { get; set; }

        public Customer Customer { get; set; }

        public Location Destination { get; set; }

        public Admin Dispatcher { get; set; }

        public Driver Driver { get; set; }

        [Display(Name = "Cost")]
        public double Amount { get; set; }

        public Comment Comment { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        [Display(Name = "State")]
        public ERideState RideState { get; set; }
    }
}