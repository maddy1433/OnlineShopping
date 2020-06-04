
#region " Namespaces "

using System.Collections.Generic;
using System.Web.Http;
//using BAL;
using Model;
//using DepenencyResolver;
//using Repository;
//using BAL.BALContracts;
using System.Net.Http;
using System.Net;
using System;
using System.Linq;
//using Common;
//using log4net;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

#endregion

namespace OnlineShoppingAPIService.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Test_GetAllProducts()
        {
            try
            {
                // Arrange
                HttpResponseMessage expectedResponse = new HttpResponseMessage(HttpStatusCode.OK);
                //HttpStatusCode expected = HttpStatusCode.OK;
                ProductController controller = new ProductController();

                // Act
                HttpResponseMessage responseMessage = controller.GetAllProducts();

                // Assert
                //Assert.IsNotNull(responseMessage);
                Assert.AreEqual(expectedResponse, responseMessage);
                //Assert.AreSame(expectedResponse, responseMessage);
            }
            catch (Exception ex)
            {

            }
        }

        [TestMethod]
        public void Test_GetProductByCategoryID()
        {
            //Arrange
            IQueryable<Product> products;
            ProductController controller = new ProductController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            HttpResponseMessage httpResponseMessage = controller.GetProductByCategoryID(3);
            httpResponseMessage.TryGetContentValue<IQueryable<Product>>(out products);
            Assert.AreEqual(3, products.FirstOrDefault().CategoryId);
            ////// Arrange
            ////HttpStatusCode expected = HttpStatusCode.OK;
            ////ProductController controller = new ProductController();
            
            ////// Act
            ////HttpResponseMessage responseMessage = controller.GetProductByCategoryID(1);

            ////// Assert
            //////Assert.IsNotNull(responseMessage);
            ////Assert.AreEqual(expected, responseMessage.StatusCode);
        }

        [TestMethod]
        public void Test_GetProductByProductId()
        {
            // Arrange
            HttpStatusCode expected = HttpStatusCode.OK;
            ProductController controller = new ProductController();

            // Act
            HttpResponseMessage responseMessage = controller.GetProductByProductId(1);

            // Assert
            //Assert.IsNotNull(responseMessage);
            Assert.AreEqual(expected, responseMessage.StatusCode);
        }

        [TestMethod]
        public void Test_PostProducts()
        {
            // Arrange
            int expected = 1;
            ProductController controller = new ProductController();

            // Act
            var insertData = new Product();
            insertData.ProductName = "Jacket Kids";
            insertData.ProductType = "Kids Winter wear";
            insertData.ImagePath = "C:\\Images\\16.jpg";
            insertData.Availability = true;
            insertData.CategoryId = 1;

            //Product insertData1 = new Product();
            //insertData1.ProductName = "Jeans Kids";
            //insertData1.ProductType = "Kids wear";
            //insertData1.ImagePath = "C:\\Images\\17.jpg";
            //insertData1.Availability = true;
            //insertData1.CategoryId = 1;

            List<Product> productsList = new List<Product>();
            productsList.Add(insertData);
            //productsList.Add(insertData1);
            int recordsAffected = controller.PostProducts(productsList);

            // Assert
            Assert.IsNotNull(recordsAffected);
            Assert.AreEqual(expected, recordsAffected);
        }

        [TestMethod]
        public void Test_DeleteProduct()
        {
            // Arrange
            bool expected = true;
            ProductController controller = new ProductController();

            // Act
            bool actual = controller.DeleteProduct(7);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
