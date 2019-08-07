using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Driver : User
    {

        public Location Location { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}