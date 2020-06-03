using Model;
using System.Collections.Generic;
using System.Linq;

namespace Repository.RepositoryContracts
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetAllProducts();
    }
}
