
using System.Collections.Generic;
using System.Web.Http;
using BAL;
using Model;
using DAL;
using DepenencyResolver;
using Repository;

namespace OnlineShoppingAPIService.Controllers
{
    public class ProductController : ApiController
    {
        IProductBAL _productBAL;
        IUnitOfWork unitofWork;

        public ProductController()
        {
            var dependencyResolver =  new DependencyResolver();
            unitofWork = dependencyResolver.CreateUoWInstance();
            _productBAL = new ProductBAL(unitofWork);
        }

        //public ProductController(IProductRepository productRepository, IUnitOfWork unitofWork)
        //{
        //    this._productBAL = new ProductBAL(unitofWork, productRepository);
        //}

        [HttpGet]
        public List<Product> GetProductByCategoryID(int id)
        {
            var product = _productBAL.GetProductByCategoryID(id);
            return product;
        }
    }
}
