using Model;

namespace Repository.RepositoryContracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetCustomerById(int id);
    }
}
