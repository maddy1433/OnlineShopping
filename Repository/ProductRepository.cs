
#region " Namespaces "
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
#endregion

namespace Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ShoppingModel dataContext;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        public ProductRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected ShoppingModel DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }
    }

    public interface IProductRepository:IRepository<Product>
    {

    }
}
