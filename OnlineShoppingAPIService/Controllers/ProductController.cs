
#region " Namespaces "

using System.Collections.Generic;
using System.Web.Http;
using BAL;
using Model;
using DepenencyResolver;
using Repository;
using BAL.BALContracts;
using System.Net.Http;
using System.Net;
using System;
using System.Linq;
using Common;
using log4net;
using System.Reflection;

#endregion

namespace OnlineShoppingAPIService.Controllers
{
    public class ProductController : ApiController
    {
        IUnitOfWork unitofWork;
        IBALContract bALContracts;
        ILog _logger = null;
        public ProductController()
        {
            var dependencyResolver = new DependencyResolver();
            this.unitofWork = dependencyResolver.CreateUoWInstance();
            this.bALContracts = new BALContract(unitofWork);
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            try
            {
                IQueryable<Product> product = bALContracts.productBAL.GetAllProducts();
                if (product != null)
                {
                    return Request.CreateResponse<IQueryable<Product>>(HttpStatusCode.OK, product);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Products Not found in this Category");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, " Products Not found in this Category");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetProductByCategoryID(int id)
        {
            HttpResponseMessage httpResponseMsg;
            try
            {
                IQueryable<Product> products = bALContracts.productBAL.GetProductByCategoryID(id);

                if (products != null)
                    httpResponseMsg = Request.CreateResponse<IQueryable<Product>>(HttpStatusCode.OK, products);
                else
                    httpResponseMsg = Request.CreateErrorResponse(HttpStatusCode.NotFound, " Products Not found in this Category");

                return httpResponseMsg;
            }
            catch(Exception ex)
            {
                httpResponseMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                _logger.Info(httpResponseMsg, ex);
                return httpResponseMsg;
            }
        }

        [HttpGet]
        public HttpResponseMessage GetProductByProductId(int id)
        {
            HttpResponseMessage httpResponseMsg;
            try
            {
                Product product = bALContracts.productBAL.GetProductByProductId(id);
                
                if (product != null)
                    httpResponseMsg = Request.CreateResponse<Product>(HttpStatusCode.OK, product);
                else
                    httpResponseMsg = Request.CreateResponse<Product>(HttpStatusCode.NotFound, product);

                return httpResponseMsg;
            }
            catch(Exception ex)
            {
                httpResponseMsg = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                _logger.Info(httpResponseMsg, ex);
                return httpResponseMsg;
            }
        }

        [HttpPost]
        //POST api/product/
        public int PostProducts([FromBody]List<Product> products)
        {
            
            //var insertData = new Product();
            //insertData.ProductName = "Jacket";
            //insertData.ProductType = "Winter wear";
            //insertData.ImagePath = "C:\\Images\\14.jpg";
            //insertData.Availability = true;
            //insertData.CategoryId = 1;

            //Product insertData1 = new Product();
            //insertData1.ProductName = "Trouse";
            //insertData1.ProductType = "Formals";
            //insertData1.ImagePath = "C:\\Images\\15.jpg";
            //insertData1.Availability = true;
            //insertData1.CategoryId = 1;

            //List<Product> productsList = new List<Product>();
            //productsList.Add(insertData);
            //productsList.Add(insertData1);
            return bALContracts.productBAL.SaveOrUpdateProduct(products);
        }

        [HttpDelete]
        //DELETE api/Product/DeleteProduct
        public bool DeleteProduct(int id)
        {
           return bALContracts.productBAL.DeleteProduct(id);

        }

    }
}
