
#region " Namespaces "

using DAL.RepositoryImplementations;
using Model;
using Repository;
using Repository.RepositoryContracts;


#endregion

namespace DAL
{ 
    /// <summary>
    /// This helps in common Commits
    /// </summary>
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ShoppingModel _dataContext;

        public ICustomerRepository Customer { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IProductRepository Product { get; private set; }

        public UnitOfWork(ShoppingModel dataContext)
        {
            _dataContext = dataContext;
            Customer = new CustomerRepository(_dataContext);
            Product = new ProductRepository(_dataContext);
            Order = new OrderRepository(_dataContext);
        }
       
        public int Commit()
        {
           return _dataContext.SaveChanges();
        }
    }

   
}
