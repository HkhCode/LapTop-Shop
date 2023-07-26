namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CABTry4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            AlterColumn("dbo.Products", "Brand_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Brand_Id");
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brands", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Brand_Id", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            AlterColumn("dbo.Products", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Products", "Brand_Id");
            AddForeignKey("dbo.Products", "Brand_Id", "dbo.Brands", "Id");
        }
    }
}
