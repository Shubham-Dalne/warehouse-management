using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseManagement.Models;

namespace WareHouseManagement.Interface
{
   public  interface IWareHouseService
    {
        List<Inventory> GetInventory();
        void AddInventory(List<Inventory> inventory);
        void SaleAndUpdateInventory(string _name, int _qty);
        void LoadInventoryJSON();
        void AddProducts(List<Product> product);
        IList<Product> GetProducts();
        void LoadProductJSON();
    }
}
