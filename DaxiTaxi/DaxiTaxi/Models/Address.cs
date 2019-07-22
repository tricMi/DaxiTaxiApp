using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Address
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        public int CallNumber { get; set; }
    }
}