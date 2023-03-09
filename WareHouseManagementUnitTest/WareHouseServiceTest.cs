using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WareHouseManagement.Services;
using Moq;
using System.Collections.Generic;
using WareHouseManagement.Models;
using WareHouseManagement.Interface;
using System.IO;

namespace WareHouseManagementUnitTest
{
    [TestClass]
    public class WareHouseServiceTest
    {
        #region Declarations

        Mock<IWarehouse> warehouse = new Mock<IWarehouse>();

        public List<Inventory> getInventoryTestList = new List<Inventory>()
        {
                                new Inventory()
                                {
                                          art_id = 1,
                                          name = "leg",
                                          stock = 12
                                },
                                new Inventory
                                {
                                          art_id = 2,
                                          name = "screw",
                                          stock = 17
                                },
                                new Inventory
                                {
                                          art_id = 3,
                                          name = "seat",
                                          stock = 2
                                },
                                new Inventory
                                {
                                          art_id = 4,
                                          name = "table top",
                                          stock = 1
                                }
                            };

        public string ProductName()
        {
            return "Dining Chair";
        }

        public List<Product> getProductsTestList = new List<Product>()
        {

            new Product()
            {
                name = "Dining Chair",
                quantity = 10,
                contain_articles = new List<Articles>(){
                   new Articles
                   {
                    art_id = "1",
                    amount_of = 4

                   },
                    new Articles
                   {
                    art_id = "2",
                    amount_of = 8

                   },
                    new Articles
                   {
                    art_id = "3",
                    amount_of = 1

                   }
                }
            },
            new Product()
            {
                name = "Dinning Table",
                quantity = 1,
                contain_articles = new List<Articles>(){
                   new Articles
                   {
                    art_id = "1",
                    amount_of = 4

                   },
                    new Articles
                   {
                    art_id = "2",
                    amount_of = 8

                   },
                    new Articles
                   {
                    art_id = "4",
                    amount_of = 1

                   }
                }
            }

        };

        public List<Product> getActiveProductsTestList = new List<Product>()
        {

            new Product()
            {
                name = "Dining Chair",
                quantity = 10,
                contain_articles = new List<Articles>(){
                   new Articles
                   {
                    art_id = "1",
                    amount_of = 4

                   },
                    new Articles
                   {
                    art_id = "2",
                    amount_of = 8

                   },
                    new Articles
                   {
                    art_id = "3",
                    amount_of = 1

                   }
                }
            }


        };

        #endregion

        #region Constructor
        public WareHouseServiceTest()
        {

        }
        #endregion

        #region TestMethods Passed Scenario

        [TestMethod]
        public void GetInventorySuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);
            
            //Act
            warehouse.Setup(x => x.inventory).Returns((getInventoryTestList));
            var actual = warehouseService.GetInventory();
            
            //Assert
            Assert.AreEqual(getInventoryTestList, actual);
        }
        
        [TestMethod]
        public void AddInventorySuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.inventory).Returns((new List<Inventory>()));
            warehouseService.AddInventory(getInventoryTestList);
           
            //Assert
            Assert.AreEqual(getInventoryTestList.Count, warehouse.Object.inventory.Count);
        }

        [TestMethod]
        public void LoadInventoryJSONSuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);
            
            //Act
            warehouse.Setup(x => x.inventory).Returns((new List<Inventory>()));
            warehouseService.LoadInventoryJSON();
            
            //Assert
            Assert.AreEqual(getInventoryTestList.Count, warehouse.Object.inventory.Count);
        }
      
        [TestMethod]
        public void UpdateInventorySuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.inventory).Returns((getInventoryTestList));
            warehouse.Setup(x => x.products).Returns((getProductsTestList));

            string _prdName = ProductName();
            int _qty = 1;
            warehouseService.SaleAndUpdateInventory(_prdName, _qty);

            //Assert
            Assert.AreSame(getInventoryTestList, warehouse.Object.inventory);
        }

        [TestMethod]
        public void AddProductSuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.products).Returns((new List<Product>()));
            warehouseService.AddProducts(getProductsTestList);

            //Assert
            Assert.AreEqual(getProductsTestList.Count, warehouse.Object.products.Count);
        }

        [TestMethod]
        public void GetProductSuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.products).Returns((getProductsTestList));
            var actual = warehouseService.GetProducts();

            //Assert
            Assert.AreEqual(getProductsTestList.Count, actual.Count);
        }

        [TestMethod]
        public void LoadProductsJSONSuccessTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.products).Returns((new List<Product>()));
            warehouseService.LoadProductJSON();

            //Assert
            Assert.AreEqual(getProductsTestList.Count, warehouse.Object.products.Count);
        }

        #endregion

        #region TestMethods Failed Scenario

        [TestMethod]
        public void GetInventoryFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.inventory).Returns(value :null);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return warehouseService.GetInventory();
            });
        }

        [TestMethod]
        public void AddInventoryFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.inventory).Returns((new List<Inventory>()));

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                warehouseService.AddInventory(null);
            });
        }
        
        [TestMethod]
        public void InventoryJSONFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);
            
            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                warehouseService.LoadInventoryJSON();
            });
        }
        [TestMethod]
        public void GetProductFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.inventory).Returns(value: null);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                return warehouseService.GetProducts();
            });
        }

        [TestMethod]
        public void AddProductFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Act
            warehouse.Setup(x => x.products).Returns((new List<Product>()));

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                warehouseService.AddProducts(null);
            });
        }
        [TestMethod]
        public void LoadProductJSONFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                warehouseService.LoadProductJSON();
            });
        }

        [TestMethod]
        public void SaleAndUpdateInventoryFailedTest()
        {
            //Arrange
            var warehouseService = new WareHouseService(warehouse.Object);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                warehouseService.SaleAndUpdateInventory(null,0);
            });

        }

        #endregion

    }
}
