using System.Collections.Generic;

namespace Cutting_edge_webapp.Models
{
    public class DropCascade
    {
        #region Request

        public List<Country> Countries { get; set; }

        #endregion

        #region Response

        public int SelectedCountryID { get; set; }
        public int SelectedCityID { get; set; }
        public int SelectedStreetID { get; set; }

        #endregion        
    }
}