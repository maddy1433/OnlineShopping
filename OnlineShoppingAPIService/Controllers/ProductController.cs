using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL;
using Model;

namespace OnlineShoppingAPIService.Controllers
{
    public class ProductController : ApiController
    {
        IProductBAL _productBAL;
        public ProductController(IProductBAL productBAL)
        {
            this._productBAL = productBAL;
        }

        [HttpGet]
        public List<Product> GetProductByCategoryID(int id)
        {//
            List<Product> products = new List<Product>();
            Product product = new Product();
            product.Availability = true;
            //product.Category = "Fashion";
            product.CategoryId = 1;
            product.ProductName = "shirt";
            products.Add(product);
            return products;
            //var product = _productBAL.GetProductByCategoryID(id);
            //return product.js;
        }
    }
}
