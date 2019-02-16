namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminDBSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 30),
                        Photo = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
