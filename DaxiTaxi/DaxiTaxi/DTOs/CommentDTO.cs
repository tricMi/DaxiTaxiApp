using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime PublishDate { get; set; }

        public UserDTO UserThatLeftComment { get; set; }

        public int Rate { get; set; }
    }
}