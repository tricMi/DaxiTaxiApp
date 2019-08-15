using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaxiTaxi.Controllers
{
    public class BookRideController : Controller
    {
        // GET: BookRide
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookARide()
        {
            return View();
        }

        public ActionResult FormARide()
        {
            return View();
        }
    }
}