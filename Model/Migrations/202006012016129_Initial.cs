namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.Int(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductType = c.String(nullable: false),
                        Availability = c.Boolean(nullable: false),
                        ImagePath = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductDetails",
                c => new
                    {
                        ProductDetailId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        ProductType = c.String(),
                    })
                .PrimaryKey(t => t.ProductDetailId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.CustomerAddresses",
                c => new
                {
                    CustomerAddressID = c.Int(nullable: false, identity: true),
                    CustomerID = c.Int(nullable: false),
                    Address = c.String(nullable: false),
                    Country = c.String(nullable: false),
                    State = c.String(),
                    Postalcode = c.String(nullable: false, maxLength: 7),
                    //Customer_CustomerID = c.Int(),
                })
                .PrimaryKey(t => t.CustomerAddressID)
                //.ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
                //.Index(t => t.Customer_CustomerID);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(),
                    Phone = c.String(),
                    Email = c.String(nullable: false),
                    //DefaultAddress_CustomerAddressID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CustomerID);
                //.ForeignKey("dbo.CustomerAddresses", t => t.DefaultAddress_CustomerAddressID, cascadeDelete: true)
                //.Index(t => t.DefaultAddress_CustomerAddressID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        DeliveryAddress = c.String(nullable: false),
                        TotalSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderedProductsID = c.Int(nullable: false),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.OrderedProducts",
                c => new
                    {
                        OrderedProductsID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Order_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderedProductsID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Order_OrderID)
                .Index(t => t.ProductID)
                .Index(t => t.Order_OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerAddresses", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerAddresses", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderedProducts", "Order_OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderedProducts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Customers", "DefaultAddress_CustomerAddressID", "dbo.CustomerAddresses");
            DropForeignKey("dbo.ProductDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Category_CategoryId", "dbo.Categories");
            DropIndex("dbo.OrderedProducts", new[] { "Order_OrderID" });
            DropIndex("dbo.OrderedProducts", new[] { "ProductID" });
            DropIndex("dbo.Orders", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Customers", new[] { "DefaultAddress_CustomerAddressID" });
            DropIndex("dbo.CustomerAddresses", new[] { "Customer_CustomerID" });
            DropIndex("dbo.CustomerAddresses", new[] { "CustomerID" });
            DropIndex("dbo.ProductDetails", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "Category_CategoryId" });
            DropTable("dbo.OrderedProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerAddresses");
            DropTable("dbo.ProductDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
