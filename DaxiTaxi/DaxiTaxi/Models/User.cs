using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 0)]
        [Required]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        [StringLength(30, ErrorMessage = "This value can't contain more than 30 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "This value can't contain more than 30 characters")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "This value can't contain more than 30 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "This value can't contain more than 30 characters")]
        public string Surname { get; set; }

        [Required]
        public EGender Gender { get; set; }

        [Required]
        [StringLength(13, ErrorMessage = "The value must contain 13 characters")]
        public string JMBG { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "This value can't contain more than 30 characters")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public ERole Role { get; set; }


    }
}