using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public enum ERole
    {
        [Display(Name = "Dispatcher")]
        ADMIN,
        [Display(Name = "Customer")]
        CUSTOMER,
        [Display(Name = "Driver")]
        DRIVER
    }
}