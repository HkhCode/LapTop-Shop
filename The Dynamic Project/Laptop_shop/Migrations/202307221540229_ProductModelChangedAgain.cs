namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductModelChangedAgain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "Card_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Card_Id", c => c.Int(nullable: false));
        }
    }
}
