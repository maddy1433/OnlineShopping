using Repository.RepositoryContracts;

namespace Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        IOrderRepository Order { get; }
        ICustomerRepository Customer { get; }
        int Commit();
    }
}
