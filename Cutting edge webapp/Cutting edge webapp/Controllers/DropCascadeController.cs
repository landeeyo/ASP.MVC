using Cutting_edge_webapp.DAL;
using Cutting_edge_webapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cutting_edge_webapp.Controllers
{
    public class DropCascadeController : Controller
    {
        //http://www.itorian.com/2013/02/cascading-dropdownlist-in-aspnet-mvc.html

        private LocalizationContext db = new LocalizationContext();

        //
        // GET: /DropCascade/

        public ActionResult Index()
        {
            ViewBag.Countries = new SelectList(db.Countries, "CountryID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(DropCascadeViewModel formData)
        {
            //TODO
            
            return RedirectToAction("Index", "Home");
        }

        //
        // POST: /Country/Edit/5

        [HttpPost]
        public ActionResult Edit(Country country)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(country);
        }

        //[HttpPost]
        //public ActionResult Index(ApplicationForm formdata)
        //{
        //    if (formdata.Name == null)
        //    {
        //        ModelState.AddModelError("Name", "Name is required field.");
        //    }
        //    if (formdata.State == null)
        //    {
        //        ModelState.AddModelError("State", "State is required field.");
        //    }
        //    if (formdata.District == null)
        //    {
        //        ModelState.AddModelError("District", "District is required field.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        //Populate the list again
        //        List<SelectListItem> state = new List<SelectListItem>();
        //        state.Add(new SelectListItem { Text = "Bihar", Value = "Bihar" });
        //        state.Add(new SelectListItem { Text = "Jharkhand", Value = "Jharkhand" });
        //        ViewBag.StateName = new SelectList(state, "Value", "Text");

        //        return View("Index");
        //    }

        //    //TODO: Database Insertion

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
