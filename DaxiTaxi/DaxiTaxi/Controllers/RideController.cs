using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaxiTaxi.Controllers
{
    public class RideController : Controller
    {
        // GET: Ride
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserPage()
        {
            return View();
        }
    }
}