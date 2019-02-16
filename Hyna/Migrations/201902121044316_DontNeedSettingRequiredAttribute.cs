namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DontNeedSettingRequiredAttribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "Logo", c => c.String(maxLength: 250));
            AlterColumn("dbo.Settings", "Phone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Settings", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Settings", "Address", c => c.String(maxLength: 250));
            AlterColumn("dbo.Settings", "Facebook", c => c.String(maxLength: 250));
            AlterColumn("dbo.Settings", "Instagram", c => c.String(maxLength: 250));
            AlterColumn("dbo.Settings", "Youtube", c => c.String(maxLength: 250));
            AlterColumn("dbo.Settings", "Lattitude", c => c.String(maxLength: 20));
            AlterColumn("dbo.Settings", "Longitude", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "Longitude", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Settings", "Lattitude", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Settings", "Youtube", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Settings", "Instagram", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Settings", "Facebook", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Settings", "Address", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Settings", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Settings", "Phone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Settings", "Logo", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
