
#region " Namespaces "
using System;
using System.Collections.Generic;
using Model;
using Repository.RepositoryContracts;
using System.Linq;
using System.Net;
#endregion

namespace DAL.RepositoryImplementations
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ShoppingModel _context;

        public ProductRepository(ShoppingModel dataContext)
            : base(dataContext)
        {
            _context = dataContext;
        }

        public ShoppingModel Context
        {
            get { return _context as ShoppingModel; }
        }

        public IQueryable<Product> GetAllProducts()
        {
            var productlist = Context.Products.AsQueryable<Product>();
            return productlist;
        }

    }

   
}
