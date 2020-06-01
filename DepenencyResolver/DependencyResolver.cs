
#region " Namespaces "

using DAL;
using Model;
using Repository;

#endregion

namespace DepenencyResolver
{
    public  class DependencyResolver
    {
        public  IUnitOfWork CreateUoWInstance()
        {
            var dataContext = new ShoppingModel();
            return new UnitOfWork(dataContext);
        }
    }
}
