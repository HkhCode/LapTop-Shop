namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategories1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoriesProducts", "Categories_Id", "dbo.Categories");
            DropForeignKey("dbo.CategoriesProducts", "Product_Id", "dbo.Products");
            DropIndex("dbo.CategoriesProducts", new[] { "Categories_Id" });
            DropIndex("dbo.CategoriesProducts", new[] { "Product_Id" });
            AddColumn("dbo.Products", "Categories_Id", c => c.Int());
            CreateIndex("dbo.Products", "Categories_Id");
            AddForeignKey("dbo.Products", "Categories_Id", "dbo.Categories", "Id");
            DropTable("dbo.CategoriesProducts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoriesProducts",
                c => new
                    {
                        Categories_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Categories_Id, t.Product_Id });
            
            DropForeignKey("dbo.Products", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categories_Id" });
            DropColumn("dbo.Products", "Categories_Id");
            CreateIndex("dbo.CategoriesProducts", "Product_Id");
            CreateIndex("dbo.CategoriesProducts", "Categories_Id");
            AddForeignKey("dbo.CategoriesProducts", "Product_Id", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoriesProducts", "Categories_Id", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
