
#region " Namespaces "
using System;
using System.Collections.Generic;
using Model;
using Repository.RepositoryContracts;
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


        public List<Product> GetProductByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
    }

   
}
