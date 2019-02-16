namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Keyword", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Keyword", c => c.String(nullable: false));
        }
    }
}
