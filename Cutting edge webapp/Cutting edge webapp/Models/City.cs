using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cutting_edge_webapp.Models
{
    public class City
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityID { get; set; }
        public string Name { get; set; }

        #endregion

        #region Foreign keys

        public int CountryID { get; set; }

        public virtual Country Country { get; set; }

        #endregion

        public virtual ICollection<Street> Streets { get; set; }
    }
}