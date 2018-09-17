using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiMus.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Taxi_AppEntities TMDB = new Taxi_AppEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}