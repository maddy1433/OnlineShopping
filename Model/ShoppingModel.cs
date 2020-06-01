namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShoppingModel : DbContext
    {
        // Your context has been configured to use a 'ShoppingModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Model.ShoppingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShoppingModel' 
        // connection string in the application configuration file.
        public ShoppingModel()
            : base("name=ShoppingModel")
        {

        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<CustomerAddress> customerAddresses { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductDetail> productDetails { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderedProducts> orderedProducts { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}