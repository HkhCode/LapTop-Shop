namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Usages", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Usages");
        }
    }
}
