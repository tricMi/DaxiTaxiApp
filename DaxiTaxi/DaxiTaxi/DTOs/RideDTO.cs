using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DaxiTaxi.DTOs
{
    public class RideDTO
    {

        public int Id { get; set; }

        public DateTime OrderDateTime { get; set; }

        public LocationDTO CustomerLocation { get; set; }

        public CustomerDTO Customer { get; set; }

        public LocationDTO Destination { get; set; }

        public AdminDTO Dispatcher { get; set; }

        public DriverDTO Driver { get; set; }

        public double Amount { get; set; }

        public CommentDTO Comment { get; set; }

        public ERideStateDTO RideState { get; set; }
    }
}