using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cutting_edge_webapp.Models
{
    public class DropDownListCascade
    {
        public List<string> CountryList { get; set; }
        public List<string> CityList { get; set; }
        public List<string> StreetList { get; set; }
    }
}