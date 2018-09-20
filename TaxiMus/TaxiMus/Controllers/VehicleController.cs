using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiMus.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle

        Taxi_AppEntities TMDB = new Taxi_AppEntities();


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string platenumber, int manufacturerid, int modelid, int categoryid, int year)
        {
            var manufacturerids = (from manufacturer in TMDB.Models.ToList()
                                   select manufacturer.ID).ToList();

            Vehicle newVehicle = new Vehicle();
            newVehicle.PlateNumber = platenumber;
            newVehicle.ManufacturerID = manufacturerid;
            newVehicle.ModelID = modelid;
            newVehicle.CategoryID = categoryid;
            newVehicle.Year = year;
            TMDB.Vehicles.Add(newVehicle);
            TMDB.SaveChanges();
            ViewBag.ManufacturerIDs = manufacturerids;
            return RedirectToAction("Read");
        }

        public ActionResult Read()
        {
            ViewBag.Vehicles = TMDB.Vehicles.ToList();
            return View();
        }
    }
}