using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Driver : User
    {
       // [Required]
        public Location Location { get; set; }

        //[Required]
        //public Vehicle Vehicle { get; set; }
    }
}