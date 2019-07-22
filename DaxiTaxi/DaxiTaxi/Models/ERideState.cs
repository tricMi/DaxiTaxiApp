using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DaxiTaxi.Models
{
    public enum ERideState
    {
        [Display(Name = "Created-On Hold")]
        Created,
        Formed,
        Processed,
        Accepted,
        Canceled,
        Successful,
        Unsuccessful
    }
}