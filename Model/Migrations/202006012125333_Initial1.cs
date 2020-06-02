namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            //DropColumn("dbo.Customers", "CustomerAddressID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerAddressID", c => c.Int(nullable: false));
            AlterColumn("dbo.Categories", "CategoryName", c => c.Int(nullable: false));
        }
    }
}
