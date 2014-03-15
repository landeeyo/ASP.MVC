using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cutting_edge_webapp.Models
{
    public class Country
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
        public string Name { get; set; }

        #endregion

        public virtual ICollection<City> Cities { get; set; }
    }
}