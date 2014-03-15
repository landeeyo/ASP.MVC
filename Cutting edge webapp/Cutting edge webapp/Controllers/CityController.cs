using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cutting_edge_webapp.Models;
using Cutting_edge_webapp.DAL;

namespace Cutting_edge_webapp.Controllers
{
    public class CityController : Controller
    {
        private LocalizationContext db = new LocalizationContext();

        //
        // GET: /City/

        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.Country);
            return View(cities.ToList());
        }

        //
        // GET: /City/Details/5

        public ActionResult Details(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // GET: /City/Create

        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            return View();
        }

        //
        // POST: /City/Create

        [HttpPost]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", city.CountryID);
            return View(city);
        }

        //
        // GET: /City/Edit/5

        public ActionResult Edit(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", city.CountryID);
            return View(city);
        }

        //
        // POST: /City/Edit/5

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name", city.CountryID);
            return View(city);
        }

        //
        // GET: /City/Delete/5

        public ActionResult Delete(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // POST: /City/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}