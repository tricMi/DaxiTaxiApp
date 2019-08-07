using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class VehicleDTO
    {

        public int Id { get; set; }

        public int VehicleYear { get; set; }

        public string RegistrationNumber { get; set; }

        public int TaxiNumber { get; set; }

        public EVehicleTypeDTO VehicleType { get; set; }
    }
}