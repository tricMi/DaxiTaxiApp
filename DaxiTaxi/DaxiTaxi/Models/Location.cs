using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Location
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public double XCoordinate { get; set; }

        [Required]
        public double YCoordinate { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}