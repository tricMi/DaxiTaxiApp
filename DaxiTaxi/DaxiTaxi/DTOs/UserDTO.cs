using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public EGenderDTO Gender { get; set; }

        public string JMBG { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public ERoleDTO Role { get; set; }
    }
}