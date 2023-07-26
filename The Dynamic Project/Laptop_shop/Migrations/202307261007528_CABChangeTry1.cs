namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CABChangeTry1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CategoriesAndBrands", newName: "Categories");
            RenameTable(name: "dbo.CategoriesAndBrandsProducts", newName: "CategoriesProducts");
            RenameColumn(table: "dbo.CategoriesProducts", name: "CategoriesAndBrands_Id", newName: "Categories_Id");
            RenameIndex(table: "dbo.CategoriesProducts", name: "IX_CategoriesAndBrands_Id", newName: "IX_Categories_Id");
            AddColumn("dbo.Products", "Brand_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Categories", "BrandOrCategory");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "BrandOrCategory", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Brand_Id");
            RenameIndex(table: "dbo.CategoriesProducts", name: "IX_Categories_Id", newName: "IX_CategoriesAndBrands_Id");
            RenameColumn(table: "dbo.CategoriesProducts", name: "Categories_Id", newName: "CategoriesAndBrands_Id");
            RenameTable(name: "dbo.CategoriesProducts", newName: "CategoriesAndBrandsProducts");
            RenameTable(name: "dbo.Categories", newName: "CategoriesAndBrands");
        }
    }
}
