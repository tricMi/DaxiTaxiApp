using DaxiTaxi.Context;
using DaxiTaxi.Models;
using DaxiTaxi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaxiTaxi.Controllers
{
    public class UserController : Controller
    {
        private TaxiAppContext _taxiContext;

        public UserController()
        {
            _taxiContext = new TaxiAppContext();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult AddDrivers()
        {
            var locations = _taxiContext.Locations.ToList();
            var vehicles = _taxiContext.Vehicles.ToList();
            var newModel = new NewDriverViewModel
            {
                Location = locations,
                Vehicle = vehicles
            };
            return View("AddDrivers", newModel);
        }

        public new ActionResult Profile()
        {
            return View();
        }
    }
}