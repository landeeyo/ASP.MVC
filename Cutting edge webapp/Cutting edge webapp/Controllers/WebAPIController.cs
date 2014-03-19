//using Cutting_edge_webapp.DAL;
//using System.Web.Http;
//using System.Web.Mvc;
//using System.Linq;
//using System.Collections.Generic;
//using Cutting_edge_webapp.Models;
//using System.Linq;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Cutting_edge_webapp.Models;
using Cutting_edge_webapp.DAL;
using System.Web.Mvc;

namespace Cutting_edge_webapp.Controllers
{
    public class WebAPIController : ApiController
    {
        private LocalizationContext db = new LocalizationContext();

        // GET: api/WebAPI/GetCityListByCountryID/5
        [System.Web.Http.HttpGet]
        public IEnumerable<ListItem> GetCityListByCountryID(int id = 0)
        {
            var cityList = db.Cities.Where(s => s.CountryID == id).ToArray();
            var result = new List<ListItem>();
            foreach (var city in cityList)
            {
                result.Add(new ListItem()
                {
                    Selected = false,
                    Text = city.Name,
                    Value = city.CityID.ToString()
                });
            }
            return result;
        }

        // GET: api/WebAPI/GetStreetListByCityID/5
        [System.Web.Http.HttpGet]
        public IEnumerable<ListItem> GetStreetListByCityID(int id = 0)
        {
            var streetList = db.Streets.Where(s => s.CityID == id).ToArray();
            var result = new List<ListItem>();
            foreach (var street in streetList)
            {
                result.Add(new ListItem()
                {
                    Selected = false,
                    Text = street.Name,
                    Value = street.StreetID.ToString()
                });
            }
            return result;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<News> GetNews()
        {
            return db.News.OrderByDescending(x => x.CreateDate).ToList();
        }
    }
}
