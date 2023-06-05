namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class try1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageData = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image1Date = c.Binary(),
                        Image2Date = c.Binary(),
                        Image3Date = c.Binary(),
                        Title = c.String(),
                        Description = c.String(),
                        Count = c.Int(nullable: false),
                        CPUModel = c.String(),
                        GPUModel = c.String(),
                        HardDrive = c.String(),
                        RamType = c.Int(nullable: false),
                        RamAmount = c.Int(nullable: false),
                        Battery = c.String(),
                        Weight = c.Int(nullable: false),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.CategoriesAndBrands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BrandOrCategory = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Description = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShopInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ShopPhone = c.String(),
                        ShopEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image1Data = c.Binary(),
                        Title1 = c.String(),
                        Description1 = c.String(),
                        Image2Data = c.Binary(),
                        Title2 = c.String(),
                        Description2 = c.String(),
                        Image3Data = c.Binary(),
                        Title3 = c.String(),
                        Description3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoriesAndBrandsProducts",
                c => new
                    {
                        CategoriesAndBrands_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoriesAndBrands_Id, t.Product_Id })
                .ForeignKey("dbo.CategoriesAndBrands", t => t.CategoriesAndBrands_Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.CategoriesAndBrands_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cards", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoriesAndBrandsProducts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.CategoriesAndBrandsProducts", "CategoriesAndBrands_Id", "dbo.CategoriesAndBrands");
            DropIndex("dbo.CategoriesAndBrandsProducts", new[] { "Product_Id" });
            DropIndex("dbo.CategoriesAndBrandsProducts", new[] { "CategoriesAndBrands_Id" });
            DropIndex("dbo.Comments", new[] { "ProductId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "Card_Id" });
            DropIndex("dbo.Cards", new[] { "UserId" });
            DropTable("dbo.CategoriesAndBrandsProducts");
            DropTable("dbo.Sliders");
            DropTable("dbo.ShopInfoes");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.CategoriesAndBrands");
            DropTable("dbo.Products");
            DropTable("dbo.Cards");
            DropTable("dbo.Adds");
        }
    }
}
