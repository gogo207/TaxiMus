using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaxiMus.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        Taxi_AppEntities TMDB = new Taxi_AppEntities();

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string name)
        {
            Category newCategory = new Category();
            newCategory.Name = name;
            TMDB.Categories.Add(newCategory);
            TMDB.SaveChanges();
            return RedirectToAction("Read");
        }

        public ActionResult Read()
        {
            ViewBag.Categories = TMDB.Categories.ToList();
            return View();
        }
    }
}