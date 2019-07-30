using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.ViewModel
{
    public class RegisterView
    {
        [Required]
        public IEnumerable<ERole> Role { get; set; }

        [Required]
        public Customer Customer { get; set; }
    }
}