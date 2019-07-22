using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public EGender Gender { get; set; }

        public string JMBG { get; set; }

        public string PhoneNumber { get; set; }

        public ERole Role { get; set; }

       // public Ride Ride { get; set; }
    }
}