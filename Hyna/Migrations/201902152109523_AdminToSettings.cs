namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminToSettings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Username", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Settings", "Password", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Settings", "AdminPhoto", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "AdminPhoto");
            DropColumn("dbo.Settings", "Password");
            DropColumn("dbo.Settings", "Username");
        }
    }
}
