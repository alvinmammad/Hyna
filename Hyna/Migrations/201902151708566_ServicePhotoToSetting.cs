namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServicePhotoToSetting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Photo", c => c.String());
            DropColumn("dbo.Services", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "Photo", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Settings", "Photo");
        }
    }
}
