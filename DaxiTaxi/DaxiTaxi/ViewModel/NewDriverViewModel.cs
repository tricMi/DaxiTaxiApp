using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.ViewModel
{
    public class NewDriverViewModel
    {
        public Driver Driver { get; set; }

        public IEnumerable<Location> Location { get; set; }

        public IEnumerable<Vehicle> Vehicle  { get; set; }
    }
}