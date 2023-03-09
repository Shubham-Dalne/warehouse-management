using Newtonsoft.Json;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WareHouseManagement.Interface;
using WareHouseManagement.Models;

namespace WareHouseManagement.Services
{

    public class WareHouseService : IWareHouseService
    {
        #region Declarations
        IWarehouse warehouse { get; set; }
        
        #endregion

        #region Constructors
       
        public WareHouseService(IWarehouse _warehouse)
        {
            warehouse = _warehouse;
        }

        #endregion

        #region Inventory Methods

        public void AddInventory(List<Inventory> inventory)
        {
            //Adding inventory data into the list of inventory which comes from AddInventory(POST) api request.

            _ = inventory ?? throw new ArgumentNullException("List of inventory is null");

            foreach (var _inv in inventory)
                warehouse.inventory.Add(_inv);
        }

        public List<Inventory> GetInventory()
        {
            //Returning inventory data to GetInventory(GET) api request from the list of inventory.

            _ = warehouse.inventory ?? throw new ArgumentNullException("Inventory is null");

            return warehouse.inventory;
        }
        
        public void LoadInventoryJSON()
        {
            // Loading inventory file from below location.

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            String Root = Directory.GetCurrentDirectory();
            string path = Path.Combine(Root, "App_Data/inventory.json");
           
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Inventory> inventory = JsonConvert.DeserializeObject<List<Inventory>>(json);
                _ = inventory ?? throw new ArgumentNullException(nameof(inventory) + " is null");

             // Adding inventory data to inventory list.

            foreach (var _inv in inventory)
                    warehouse.inventory.Add(_inv);
            }
        }

        #endregion

        #region Product Methods

        public void AddProducts(List<Product> product)
        {
            //Adding products data into the list of products which comes from Addproducts(POST) api request.

            _ = product ?? throw new ArgumentNullException(nameof(product) + " is null");

            foreach (var _prd in product)
                    warehouse.products.Add(_prd);
        }

        public IList<Product> GetProducts()
        {
            //Returning products data to GetProducts(GET) api request from the list of products.

            _ = warehouse.products ?? throw new ArgumentNullException("Products is null");

            return warehouse.products.ToList(); ;
        }

        public void LoadProductJSON()
        {
            // Loading products file from below location.

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            String Root = Directory.GetCurrentDirectory();
            string path = Path.Combine(Root, "App_Data/products.json");
            
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Product> product = JsonConvert.DeserializeObject<List<Product>>(json);
                _ = product ?? throw new ArgumentNullException(nameof(product) + " is null");

            // Adding product data to the products list.

            foreach (var _prd in product)
                     warehouse.products.Add(_prd);
            }
        }

        #endregion

        #region Sale & Update Method

        public void SaleAndUpdateInventory(string productName, int quantity)
        {
            // Checking that requested product and quantity is available in the product list or not.
            Product productList = warehouse.products.Where(a => a.name == productName && a.quantity >= quantity).FirstOrDefault();
            _ = productList ?? throw new ArgumentNullException(nameof(productList) + " is null");
            
            // Once product is available with requested quantity then checking product contain inventory is available or not.
            foreach (var data in productList.contain_articles.ToList())
            {
                Inventory inventoryList = warehouse.inventory.Where
                                        (a => a.art_id == Convert.ToDouble(data.art_id)
                                        && a.stock >= data.amount_of).FirstOrDefault();

                _ = inventoryList ?? throw new ArgumentNullException(nameof(inventoryList) + "is null");

                // Updating inventory once product sold out.
                inventoryList.stock = inventoryList.stock - data.amount_of;
            }

            //Updating product quantity once product sold out.
            productList.quantity = productList.quantity - quantity;
            if (productList.quantity <= 0)
                warehouse.products.RemoveAll(a => a.name == productName);
        }

        #endregion
    }

}    