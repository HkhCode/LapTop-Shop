namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddsChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adds", "AddNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Sliders", "slider_Id", c => c.Int());
            CreateIndex("dbo.Sliders", "slider_Id");
            AddForeignKey("dbo.Sliders", "slider_Id", "dbo.Sliders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sliders", "slider_Id", "dbo.Sliders");
            DropIndex("dbo.Sliders", new[] { "slider_Id" });
            DropColumn("dbo.Sliders", "slider_Id");
            DropColumn("dbo.Adds", "AddNumber");
        }
    }
}
