namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCategory2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "Categories_Id" });
            DropColumn("dbo.Products", "Categories_Id");
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "Categories_Id", c => c.Int());
            CreateIndex("dbo.Products", "Categories_Id");
            AddForeignKey("dbo.Products", "Categories_Id", "dbo.Categories", "Id");
        }
    }
}
