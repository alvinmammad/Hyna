namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryToService : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "CategoryID");
            AddForeignKey("dbo.Services", "CategoryID", "dbo.Categories", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Services", new[] { "CategoryID" });
            DropColumn("dbo.Services", "CategoryID");
        }
    }
}
