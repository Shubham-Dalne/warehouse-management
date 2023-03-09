using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WareHouseManagement.Models
{
    public class Inventory
    {
        public int art_id { get; set; }

        public string name { get; set; }

        public int stock { get; set; }
    }
}