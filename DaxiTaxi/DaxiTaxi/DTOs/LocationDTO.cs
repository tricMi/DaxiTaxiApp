using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class LocationDTO
    {

        public int Id { get; set; }

        public double XCoordinate { get; set; }

        public double YCoordinate { get; set; }

        public AddressDTO Address { get; set; }
    }
}