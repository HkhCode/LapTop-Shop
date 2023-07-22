namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelChanged2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image1Data", c => c.Binary());
            AddColumn("dbo.Products", "Image2Data", c => c.Binary());
            AddColumn("dbo.Products", "Image3Data", c => c.Binary());
            DropColumn("dbo.Products", "Image1Date");
            DropColumn("dbo.Products", "Image2Date");
            DropColumn("dbo.Products", "Image3Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Image3Date", c => c.Binary());
            AddColumn("dbo.Products", "Image2Date", c => c.Binary());
            AddColumn("dbo.Products", "Image1Date", c => c.Binary());
            DropColumn("dbo.Products", "Image3Data");
            DropColumn("dbo.Products", "Image2Data");
            DropColumn("dbo.Products", "Image1Data");
        }
    }
}
