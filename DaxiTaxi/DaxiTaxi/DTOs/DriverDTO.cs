using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class DriverDTO
    {
        public LocationDTO Location { get; set; }

        public VehicleDTO Vehicle { get; set; }
    }
}