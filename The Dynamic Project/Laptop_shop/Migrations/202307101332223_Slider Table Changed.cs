namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SliderTableChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sliders", "slider_Id", "dbo.Sliders");
            DropIndex("dbo.Sliders", new[] { "slider_Id" });
            DropColumn("dbo.Sliders", "slider_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sliders", "slider_Id", c => c.Int());
            CreateIndex("dbo.Sliders", "slider_Id");
            AddForeignKey("dbo.Sliders", "slider_Id", "dbo.Sliders", "Id");
        }
    }
}
