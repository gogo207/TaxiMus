using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiMus.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        Taxi_AppEntities TMDB = new Taxi_AppEntities();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            Model newModel = new Model();
            newModel.Name = name;
            TMDB.Models.Add(newModel);
            TMDB.SaveChanges();
            return RedirectToAction("Read");
        }
        
        public ActionResult Read()
        {
            ViewBag.Models = TMDB.Models.ToList();
            return View();
        }
    }
}