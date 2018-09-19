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
        
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create(string login, string password)
        {
            Admin newAdmin = new Admin();
            newAdmin.Login = login;
            newAdmin.Password = password;
            TMDB.Admins.Add(newAdmin);
            TMDB.SaveChanges();
            return RedirectToAction("Read");
        }

        public ActionResult Read()
        {
            ViewBag.Admins = TMDB.Admins.ToList();
            return View();
        }
    }
}