using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaxiMus;

namespace TaxiMus.Controllers
{
    public class VehicleControllerTest : Controller
    {
        private Taxi_AppEntities db = new Taxi_AppEntities();

        // GET: VehicleControllerTest
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Category).Include(v => v.Manufacturer).Include(v => v.Model);
            return View(vehicles.ToList());
        }

        // GET: VehicleControllerTest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: VehicleControllerTest/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name");
            ViewBag.ModelID = new SelectList(db.Models, "ID", "Name");
            return View();
        }

        // POST: VehicleControllerTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PlateNumber,ManufacturerID,ModelID,CategoryID,Year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", vehicle.CategoryID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name", vehicle.ManufacturerID);
            ViewBag.ModelID = new SelectList(db.Models, "ID", "Name", vehicle.ModelID);
            return View(vehicle);
        }

        // GET: VehicleControllerTest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", vehicle.CategoryID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name", vehicle.ManufacturerID);
            ViewBag.ModelID = new SelectList(db.Models, "ID", "Name", vehicle.ModelID);
            return View(vehicle);
        }

        // POST: VehicleControllerTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PlateNumber,ManufacturerID,ModelID,CategoryID,Year")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", vehicle.CategoryID);
            ViewBag.ManufacturerID = new SelectList(db.Manufacturers, "ID", "Name", vehicle.ManufacturerID);
            ViewBag.ModelID = new SelectList(db.Models, "ID", "Name", vehicle.ModelID);
            return View(vehicle);
        }

        // GET: VehicleControllerTest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: VehicleControllerTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
