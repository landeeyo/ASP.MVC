﻿using Cutting_edge_webapp.DAL;
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
            ViewBag.CountryID = new SelectList(db.Countries, "CountryID", "Name");
            ViewBag.CityID = new SelectList(db.Cities, "CityID", "Name");
            ViewBag.StreetID = new SelectList(db.Streets, "StreetID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Index(DropCascade formdata)
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}