# WareHouse Management

## Contents 

 - Introduction
 - Features
 - Software Requirements
 - Installation
 - API Details
 - Success Unit Test Cases
 - Failed Unit Test Cases
 - Links
 - About Me

## Introduction

Warehouse Management application aims to provide different API's for loading inventory and products data, retriving inventory and product details,selling products and update inventory accordingly.

## Features
WareHouse Api involves two main Features

- Get all products and quantity of each that is an available with the current inventory.

- Sale a product and update the inventory accordingly.

- Implemented dependency injection using unity framework.

## Software Requirements
- Visual Studio 2017
- Postman

## Installation
- Visual Studio link for downloading
https://my.visualstudio.com

- Postman link for downloading
https://www.postman.com/downloads/


## API Details
1) LoadInventory
This API will read data from inventory.json file which is available in WareHouseManagement/App_Data folder.

- URL for read inventory file is given below.
- GET: http://localhost:50968/Warehouse/LoadInventory


2) LoadProducts
- This API will read data from products.json file which is available in WareHouseManagement/App_Data folder.

- URL for read products file is given below.
- GET:http://localhost:50968/Warehouse/LoadProducts

3) AddInventory
- This API is responsible for aading inventory.

- URL for adding inventory is given below.
- POST: http://localhost:50968/Warehouse/AddInventory

- Payload For AddInventory API:
- [
    {
      "art_id": "1",
      "name": "leg",
      "stock": "12"
    },
    {
      "art_id": "2",
      "name": "screw",
      "stock": "17"
    },
    {
      "art_id": "3",
      "name": "seat",
      "stock": "2"
    },
    {
      "art_id": "4",
      "name": "table top",
      "stock": "1"
    }
  ]

4) GetInventory

- This API is responsible for loading inventory which is added using AddInventory API.

- URL for loading inventory is given below.
- GET: http://localhost:50968/Warehouse/GetInventory

5) AddProducts

- This API is responsible for aading products.

- URL for adding products is given below.
- POST: http://localhost:50968/Warehouse/AddProducts

- Payload For AddInventory API:
  - [
    {
      "name": "Dining Chair",
      "quantity":"1",
      "contain_articles": [
        {
          "art_id": "1",
          "amount_of": "4"
        },
        {
          "art_id": "2",
          "amount_of": "8"
        },
        {
          "art_id": "3",
          "amount_of": "1"
        }
      ]
    },
  {
    "name": "Dinning Table",
    "quantity":"1",
    "contain_articles": [
      {
        "art_id": "1",
        "amount_of": "4"
      },
      {
        "art_id": "2",
        "amount_of": "8"
      },
      {
        "art_id": "4",
        "amount_of": "1"
      }
    ]
  }
  ]


6) GetProducts

- This API is responsible for loading products which is added using AddProducts API.

- URL for loading products is given below.
- GET: http://localhost:50968/Warehouse/GetProduct

7) Sale&UpdateInventory

- This API is responsible for selling product and updating inventory accordingly.
- This API firstly check whether product is available or not.
- If product is available then it checks the quantity of specific product.
- If product selling quantity is less than available quantity then it allows to sale that specific product.
- After selling the product it updates inventory accordingly.

- URL for selling product and updating inventory is given below.
- GET: http://localhost:50968/Warehouse/UpdateInventory?name=Dinning Table&qty=1
 
## Unit Test Cases
- For checking whether API returns expected output or not we have written unit test cases.
- Test cases written under WareHouseManagementUnitTest/WareHouseServiceTest.

1) GetInventorySuccessTest()
- This test case is written to check whether GetInventory API returns expected output or not.

2) AddInventorySuccessTest()
- This test case is written to check whether AddInventory API returns expected output or not.

3) LoadInventoryJSONSuccessTest()
- This test case used to check whether LoadInventory API loaded expected inventory.json file or not.

4) UpdateInventorySuccessTest()
- This unit test case written to check whether Sale&UpdateInventory API sales and update inventory successfully or not.

5) AddProductSuccessTest()
- This test case is written to check whether AddProducts API returns expected output or not.

6) GetProductSuccessTest()
- This test case is written to check whether GetProducts API returns expected output or not.

7) LoadProductsJSONSuccessTest()
- This test case used to check whether LoadProducts API loaded expected products.json file or not.

## Failed Unit Test Cases

1) GetInventoryFailedTest()
- This test case is written to check whether GetInventory API returns expected null exception or not.

2) AddInventoryFailedTest()
- This test case is written to check whether AddInventory API returns expected null exception or not.

3) InventoryJSONFailedTest()
- This test case used to check whether LoadInventory API return expected null exception or not.

4) GetProductFailedTest()
- This test case is written to check whether GetProducts API returns expected null exception or not.

5) AddProductFailedTest()
- This test case is written to check whether AddProducts API returns expected null exception or not.

6) LoadProductJSONFailedTest()
- This test case used to check whether LoadProducts API return expected null exception or not.

7) SaleAndUpdateInventoryFailedTest()
- This unit test case written to check whether Sale&UpdateInventory API return expected exception or not when we pass wrong input to that  function.

## Links
https://github.com/Shubham-Dalne/warehouse-management.git

## About Me
- Shubham Dalne

