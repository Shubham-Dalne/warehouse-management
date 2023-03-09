using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseManagement.Models;

namespace WareHouseManagement.Interface
{
   public interface IWarehouse
    {
        List<Product> products { get; set; }
        List<Inventory> inventory { get; set; }
        IList<Articles> articles { get; set; }
    }
}
