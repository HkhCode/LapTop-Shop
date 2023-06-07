namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SelectedForHomePage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SelectedForHomePage");
        }
    }
}
