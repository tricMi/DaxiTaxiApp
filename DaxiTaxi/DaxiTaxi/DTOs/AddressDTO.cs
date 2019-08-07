using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public string Street { get; set; }

        public int StreetNumber { get; set; }

        public string City { get; set; }

        public int CallNumber { get; set; }
    }
}