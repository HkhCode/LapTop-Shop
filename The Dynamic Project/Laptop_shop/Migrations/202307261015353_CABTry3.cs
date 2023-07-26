namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CABTry3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Brand_Id1" });
            DropColumn("dbo.Products", "Brand_Id");
            RenameColumn(table: "dbo.Products", name: "Brand_Id1", newName: "Brand_Id");
            AlterColumn("dbo.Products", "Brand_Id", c => c.Int());
            CreateIndex("dbo.Products", "Brand_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Brand_Id" });
            AlterColumn("dbo.Products", "Brand_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Products", name: "Brand_Id", newName: "Brand_Id1");
            AddColumn("dbo.Products", "Brand_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Brand_Id1");
        }
    }
}
