using Model;
using System.Collections.Generic;


namespace Repository.RepositoryContracts
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductByCategoryId(int id);
    }
}
