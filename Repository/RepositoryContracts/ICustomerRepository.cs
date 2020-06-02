using Model;

namespace Repository.RepositoryContracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerDetailsById(int id);
    }
}
