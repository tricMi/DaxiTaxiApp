using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.ViewModel
{
    public class UserView
    {
        [Required(ErrorMessage = "You must enter username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter password")]
        public string Password { get; set; }
    }
}