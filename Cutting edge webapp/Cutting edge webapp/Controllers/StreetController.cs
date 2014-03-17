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
    public class StreetController : Controller
    {
        private LocalizationContext db = new LocalizationContext();

        //
        // GET: /Street/

        public ActionResult Index()
        {
            var streets = db.Streets.Include(s => s.City);
            return View(streets.ToList());
        }

        //
        // GET: /Street/Details/5

        public ActionResult Details(int id = 0)
        {
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        //
        // GET: /Street/Create

        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            return View();
        }

        //
        // POST: /Street/Create

        [HttpPost]
        public ActionResult Create(Street street)
        {
            if (ModelState.IsValid)
            {
                db.Streets.Add(street);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", street.CityID);
            return View(street);
        }

        //
        // GET: /Street/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", street.CityID);
            return View(street);
        }

        //
        // POST: /Street/Edit/5

        [HttpPost]
        public ActionResult Edit(Street street)
        {
            if (ModelState.IsValid)
            {
                db.Entry(street).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name", street.CityID);
            return View(street);
        }

        //
        // GET: /Street/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Street street = db.Streets.Find(id);
            if (street == null)
            {
                return HttpNotFound();
            }
            return View(street);
        }

        //
        // POST: /Street/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Street street = db.Streets.Find(id);
            db.Streets.Remove(street);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        ////
        //// GET: /Street/ListByCity/5

        //public JsonResult ListByCity(int id = 0)
        //{
        //    var streetList = db.Streets.Where(s => s.CityID == id).ToArray();
        //    return Json(new SelectList(streetList, "StreetID", "Name"), JsonRequestBehavior.AllowGet);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}