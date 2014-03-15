using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cutting_edge_webapp.Models
{
    public class Street
    {
        #region Fields

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StreetID { get; set; }
        public string Name { get; set; }

        #endregion

        #region Foreign keys

        public int CityID { get; set; }

        public virtual City City{ get; set; }

        #endregion
    }
}