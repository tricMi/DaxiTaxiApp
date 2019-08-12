using DaxiTaxi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DaxiTaxi.Controllers.api
{
    public class ManageRideAPIController : ApiController
    {
        private TaxiAppContext _taxiContext;

        public ManageRideAPIController()
        {
            _taxiContext = new TaxiAppContext();
        }

       
    }
}
