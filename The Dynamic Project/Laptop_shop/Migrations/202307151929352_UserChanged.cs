namespace Laptop_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "Family", c => c.String());
            DropColumn("dbo.Users", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Username", c => c.String());
            DropColumn("dbo.Users", "Family");
            DropColumn("dbo.Users", "Name");
        }
    }
}
