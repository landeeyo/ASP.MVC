using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cutting_edge_webapp.Models
{
    /// <summary>
    /// Class used to represent dropdownlist item in web api
    /// </summary>
    public class ListItem
    {
        public bool Selected { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
    }
}