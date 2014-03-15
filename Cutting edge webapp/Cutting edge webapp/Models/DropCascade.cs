using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cutting_edge_webapp.Models
{
    public class DropCascade
    {
        #region Request

        public List<Country> Countries { get; set; }
        public List<City> Cities { get; set; }
        public List<Street> Streets { get; set; }

        #endregion

        #region Response

        public int SelectedCountryID { get; set; }
        public int SelectedCityID { get; set; }
        public int SelectedStreetID { get; set; }

        #endregion        
    }
}