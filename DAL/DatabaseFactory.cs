using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    #region We will create instance of ShoppingModel (our db context class) once and handle disposing.

    /// <summary>
    /// Team here am trying to create a singleton object, as we dont have to initialize dbContext again and again.
    /// If the request is coming for the first time then we will initialze and give the dbContext object otherwise just return the dbContext object.
    /// </summary>
    public class DatabaseFactory : IDisposable, IDatabaseFactory
    {
        private ShoppingModel dataContext;
        
        public ShoppingModel Get()
        {
            return dataContext ?? (dataContext = new ShoppingModel());
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool isDisposable)
        {

        }
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseFactory:IDisposable
    {
        ShoppingModel Get();
    }
}
