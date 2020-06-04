namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAndOrderClassModified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderedProducts", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderedProducts", new[] { "Order_OrderID" });
            RenameColumn(table: "dbo.OrderedProducts", name: "Order_OrderID", newName: "OrderId");
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderedProducts", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderedProducts", "OrderId");
            AddForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedProducts", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedProducts", new[] { "OrderId" });
            AlterColumn("dbo.OrderedProducts", "OrderId", c => c.Int());
            DropColumn("dbo.Orders", "CustomerId");
            RenameColumn(table: "dbo.OrderedProducts", name: "OrderId", newName: "Order_OrderID");
            CreateIndex("dbo.OrderedProducts", "Order_OrderID");
            AddForeignKey("dbo.OrderedProducts", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
