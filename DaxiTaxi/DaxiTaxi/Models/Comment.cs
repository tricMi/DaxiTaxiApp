using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        [Display(Name = "User that left comment")]
        public User UserThatLeftComment { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Rate must be between 0-5")]
        public int Rate { get; set; }
    }
}