namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductChanged1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Card_Id", "dbo.Cards");
            DropIndex("dbo.Products", new[] { "Card_Id" });
            CreateTable(
                "dbo.ProductCards",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Card_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Card_Id);
            
            AlterColumn("dbo.Products", "Card_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCards", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.ProductCards", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductCards", new[] { "Card_Id" });
            DropIndex("dbo.ProductCards", new[] { "Product_Id" });
            AlterColumn("dbo.Products", "Card_Id", c => c.Int());
            DropTable("dbo.ProductCards");
            CreateIndex("dbo.Products", "Card_Id");
            AddForeignKey("dbo.Products", "Card_Id", "dbo.Cards", "Id");
        }
    }
}
