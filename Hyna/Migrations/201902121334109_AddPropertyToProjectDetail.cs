namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyToProjectDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Keyword", c => c.String(nullable: false));
            AddColumn("dbo.Projects", "ProjectList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProjectList");
            DropColumn("dbo.Projects", "Keyword");
        }
    }
}
