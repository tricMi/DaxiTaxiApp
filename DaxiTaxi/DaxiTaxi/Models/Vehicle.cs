using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        [Required]
        public int Id { get; set; }

        //[Required]
        //public Driver Driver { get; set; }

        [Required]
        [Display(Name = "Vehicle Year")]
        public int VehicleYear { get; set; }

        [Required]
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [Display(Name = "Taxi Number")]
        public int TaxiNumber { get; set; }

        [Required]
        [Display(Name = "Vehicle Type")]
        public EVehicleType VehicleType { get; set; }
    }
}