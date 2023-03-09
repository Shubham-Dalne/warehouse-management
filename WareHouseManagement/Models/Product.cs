using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WareHouseManagement.Models
{
    public class Product
    {
        public string name { get; set; }

        public int quantity { get; set; }

        public List<Articles> contain_articles { get; set; }
        
    }
    public class Articles
    {
        public string art_id { get; set; }
        public int amount_of { get; set; }
    }

}