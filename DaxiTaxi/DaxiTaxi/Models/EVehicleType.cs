using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public enum EVehicleType
    {
        Empty,
        [Display(Name = "Passenger Vehicle")]
        PassengerVehicle,
        Van
    }
}