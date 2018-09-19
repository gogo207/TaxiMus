using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiMus.Controllers
{
    public class ManufacturerController : Controller
    {
        // GET: Manufacturer

        Taxi_AppEntities TMDB = new Taxi_AppEntities();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            Manufacturer newManufacturer = new Manufacturer();
            newManufacturer.Name = name;
            TMDB.Manufacturers.Add(newManufacturer);
            TMDB.SaveChanges();
            return RedirectToAction("Read");
        }

        public ActionResult Read()
        {
            ViewBag.Manufacturers = TMDB.Manufacturers.ToList();
            return View();
        }
    }
}