
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WareHouseManagement.CustomException;
using WareHouseManagement.Interface;
using WareHouseManagement.Models;
using WareHouseManagement.Services;

namespace WareHouseManagement.Controllers
{
    [RoutePrefix("Warehouse")]
    public class WareHouseController : ApiController
    {
        #region Declarations
        IWareHouseService services { get; set; }
        NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructor
        public WareHouseController(IWareHouseService _services)
        {
            services = _services;
        }
        #endregion

        #region Inventory Methods

        [HttpPost, Route("AddInventory")]
        public HttpResponseMessage AddInventory(List<Inventory> inventory)
        {
            // This method will request to service class method for adding data into inventory list.

            try
            {
                services.AddInventory(inventory);
                return Request.CreateResponse(HttpStatusCode.OK, "Inventory Added Successfully..!!");
            }
            catch(Exception ex)
            {
                logger.Error(ex,ex.Message);
                throw;
            }
        }

        [HttpGet, Route("GetInventory")]
        public HttpResponseMessage GetInventory()
        {
            // This method will request to service class method for returning data from inventory list.

            try
            {
                List<Inventory> inventoryList = services.GetInventory();
                if (inventoryList != null && inventoryList.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, inventoryList);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data found");
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }

        }

        [HttpGet, Route("UpdateInventory")]
        public HttpResponseMessage UpdateInventory(string name, int qty)
        {
            // This method will request to service class method for selling product and update inventory.

            try
            {
                services.SaleAndUpdateInventory(name, qty);
                return Request.CreateResponse(HttpStatusCode.OK, "Product Sales Successfully..!!");
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
      
        }

        [HttpGet, Route("LoadInventory")]
        public HttpResponseMessage LoadInventory()
        {
            // This method will request service class method to load inventory file.

            try
            {
                services.LoadInventoryJSON();
                return Request.CreateResponse(HttpStatusCode.OK, "Inventory Loaded Successfully..!!");
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

        #endregion

        #region Product Methods

        [HttpPost, Route("AddProducts")]
        public HttpResponseMessage AddProducts(List<Product> product)
        {
            // This method will request to service class method for adding data into products list.

            try
            {
                services.AddProducts(product);
                return Request.CreateResponse(HttpStatusCode.OK, "Product Added Successfully..!!");
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
          
        }

        [HttpGet, Route("GetProduct")]
        public HttpResponseMessage GetProducts()
        {
            // This method will request to service class method for returning data from products list.

            try
            {
                List<Product> productList = services.GetProducts().ToList();
                if (productList != null && productList.Count > 0)
                    return Request.CreateResponse(HttpStatusCode.OK, productList);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No data found");
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
         
        }

        [HttpGet, Route("LoadProducts")]
        public HttpResponseMessage LoadProducts()
        {
            // This method will request service class method to load products file.

            try
            {
                services.LoadProductJSON();
                return Request.CreateErrorResponse(HttpStatusCode.OK, "Products Loaded Successfully...!!");
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
            
        }

        #endregion
    }

}
