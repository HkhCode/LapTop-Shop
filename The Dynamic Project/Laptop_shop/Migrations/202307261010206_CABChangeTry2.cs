namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CABChangeTry2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductCards", newName: "CardProducts");
            DropPrimaryKey("dbo.CardProducts");
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Brand_Id1", c => c.Int());
            AddPrimaryKey("dbo.CardProducts", new[] { "Card_Id", "Product_Id" });
            CreateIndex("dbo.Products", "Brand_Id1");
            AddForeignKey("dbo.Products", "Brand_Id1", "dbo.Brands", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Brand_Id1", "dbo.Brands");
            DropIndex("dbo.Products", new[] { "Brand_Id1" });
            DropPrimaryKey("dbo.CardProducts");
            DropColumn("dbo.Products", "Brand_Id1");
            DropTable("dbo.Brands");
            AddPrimaryKey("dbo.CardProducts", new[] { "Product_Id", "Card_Id" });
            RenameTable(name: "dbo.CardProducts", newName: "ProductCards");
        }
    }
}
