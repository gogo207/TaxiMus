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
            var manufacturerlist = (from manufacturer in TMDB.Manufacturers.ToList()
                                   select manufacturer.Name).ToList();
            ViewBag.Manufacturerlist = manufacturerlist;

            var modellist = (from model in TMDB.Models.ToList()
                                    select model.Name).ToList();
            ViewBag.Modellist = modellist;

            var categorylist = (from category in TMDB.Categories.ToList()
                                    select category.Name).ToList();
            ViewBag.Categorylist = categorylist;
            return View();
        }

        [HttpPost]
        public ActionResult Create(string platenumber, string manufacturer, string model, string category, int year)
        {
            //var manufacturerids = (from manufacturer in TMDB.Manufacturers.ToList()
            //                       select manufacturer.ID).ToList();

            var manid = (from manuid in TMDB.Manufacturers
                        where manufacturer == manuid.Name
                        select manuid.ID).ToList();

            var modid = (from modelid in TMDB.Models
                         where model == modelid.Name
                         select modelid.ID).ToList();

            var catid = (from cateid in TMDB.Categories
                         where category == cateid.Name
                         select cateid.ID).ToList();






            Vehicle newVehicle = new Vehicle();
            newVehicle.PlateNumber = platenumber;
            newVehicle.ManufacturerID = manid[0];
            newVehicle.ModelID = modid[0];
            newVehicle.CategoryID = catid[0];
            newVehicle.Year = year;
            TMDB.Vehicles.Add(newVehicle);
            TMDB.SaveChanges();
            //ViewBag.ManufacturerIDs = manufacturerids;
            return RedirectToAction("Read");
        }

        public ActionResult Read()
        {
            //ViewBag.Vehicles = 
            return View(TMDB.Vehicles.ToList());
        }
    }
}