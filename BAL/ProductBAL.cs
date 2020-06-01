
#region " Namespaces "
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using Repository;
#endregion

namespace BAL
{

    #region We will implement the business logic here, this will be consumed by API Service

    public class ProductBAL : IProductBAL
    {

        IUnitOfWork unitOfWork;
        IProductRepository _productsRepository;

        public ProductBAL(
            IUnitOfWork unitOfWork,
            IProductRepository productsRepository)
        {
            this.unitOfWork = unitOfWork;
            this._productsRepository = productsRepository;
        }

        public List<Product> GetProductByCategoryID(int id)
        {
            List<Product> products;
            products = _productsRepository.GetMany(x => x.CategoryId == id).ToList();
            return products;
        }
    }

    #endregion

    public interface IProductBAL
    {
        List<Product> GetProductByCategoryID(int id);
    }
}
