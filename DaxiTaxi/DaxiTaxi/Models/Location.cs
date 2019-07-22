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
        public decimal XCoordinate { get; set; }

        [Required]
        public decimal YCoordinate { get; set; }

        [Required]
        public Address Address { get; set; }
    }
}