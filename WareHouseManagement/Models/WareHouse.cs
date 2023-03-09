using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WareHouseManagement.Interface;
using WareHouseManagement.Services;

namespace WareHouseManagement.Models
{
    public class WareHouse : IWarehouse
    {
        #region Declaration

        private static WareHouse warehouse = null;

        public List<Product> products { get; set; }
        public List<Inventory> inventory { get; set; }
        public IList<Articles> articles { get; set; }

        #endregion

        #region Methods
        public WareHouse()
        {
            products  = new List<Product>();
            inventory = new List<Inventory>();
            articles  = new List<Articles>();
        }

        
        #endregion
    }
}