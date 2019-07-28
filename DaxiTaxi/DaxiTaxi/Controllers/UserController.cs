using DaxiTaxi.Context;
using DaxiTaxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DaxiTaxi.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Login()
        {
            return View();
        }

    }
}