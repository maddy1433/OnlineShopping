
#region " Namespaces "

using System.Collections.Generic;
using System.Linq;
using Model;
using Repository;
using Repository.RepositoryContracts;

#endregion

namespace BAL
{

    #region We will implement the business logic here, this will be consumed by API Service

    public class ProductBAL : IProductBAL
    {

        IUnitOfWork unitOfWork;
        IProductRepository _productsRepository;
        public ProductBAL(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _productsRepository = unitOfWork.Product;
        }
        
        public List<Product> GetProductByCategoryID(int id)
        {
            List<Product> products;
            products = _productsRepository.GetProductByCategoryId(id); //GetMany(x => x.CategoryId == id).ToList();
            return products;
        }
    }

    #endregion

    public interface IProductBAL
    {
        List<Product> GetProductByCategoryID(int id);
    }
}
