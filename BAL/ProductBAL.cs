
#region " Namespaces "

using System.Collections.Generic;
using System.Linq;
using Model;
using Repository;
using Repository.RepositoryContracts;
using System.Data;
using System.Data.Entity;


#endregion

namespace BAL
{

    #region Implementation

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

        public IQueryable<Product> GetAllProducts()
        {
            var products = _productsRepository.GetAllProducts().Where(x=>x.Availability == true); //GetMany(x => x.CategoryId == id).ToList();
            return products;
        }
        
        public IQueryable<Product> GetProductByCategoryID(int id)
        {
            var products = _productsRepository.GetAllProducts().Where(x => x.CategoryId == id && x.Availability==true).AsQueryable<Product>();
            return products;
        }

        public Product GetProductByProductId(int id)
        {
            var products = _productsRepository.GetAllProducts().SingleOrDefault(c => c.ProductId == id && c.Availability == true);
            return products;
            
        }

        public int SaveOrUpdateProduct(List<Product> products)
        {
            if (products != null)
            {
                foreach (var product in products)
                {
                    Product _product;
                    if (product.ProductId != 0)
                        _product = _productsRepository.GetById(product.ProductId);
                    else
                        _product = new Product();

                    _product.ProductName = product.ProductName;
                    _product.ProductType = product.ProductType;
                    _product.Availability = product.Availability;
                    _product.ImagePath = product.ImagePath;
                    _product.CategoryId = product.CategoryId;
                    if (product.ProductId != 0)
                        _productsRepository.Update(_product);
                    else
                        _productsRepository.Add(_product);
                }
                return unitOfWork.Commit();
            }
            return 0;
        }

        public bool DeleteProduct(int id)
        {
            var product = _productsRepository.GetAllProducts().SingleOrDefault(c => c.ProductId == id && c.Availability==true);
            if (product != null)
            {
                product.Availability = false;
                _productsRepository.Update(product);
                unitOfWork.Commit();
                return true;
            }
            return false;
        }
    }

    #endregion

    public interface IProductBAL
    {
        IQueryable<Product> GetAllProducts();
        IQueryable<Product> GetProductByCategoryID(int id);
        Product GetProductByProductId(int id);
        int SaveOrUpdateProduct(List<Product> products);
        bool DeleteProduct(int id);

    }
}
