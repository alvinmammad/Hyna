namespace Hyna.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false),
                        Photo = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Fullname = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 50),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 1000),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false),
                        AuthorID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProjectCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProjectID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.ProjectID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Facts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Orderby = c.Int(nullable: false),
                        Key = c.String(nullable: false, maxLength: 250),
                        Value = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FaqCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 200),
                        Answer = c.String(nullable: false, maxLength: 200),
                        CategoryID = c.Int(nullable: false),
                        FaqCategory_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.FaqCategories", t => t.FaqCategory_ID)
                .Index(t => t.CategoryID)
                .Index(t => t.FaqCategory_ID);
            
            CreateTable(
                "dbo.Partners",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        URL = c.String(nullable: false, maxLength: 250),
                        Logo = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Orderby = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Icon = c.String(nullable: false, maxLength: 250),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Description = c.String(nullable: false, maxLength: 100),
                        Text = c.String(nullable: false),
                        PDF = c.String(nullable: false, maxLength: 250),
                        Document = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Logo = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 250),
                        Facebook = c.String(nullable: false, maxLength: 250),
                        Instagram = c.String(nullable: false, maxLength: 250),
                        Youtube = c.String(nullable: false, maxLength: 250),
                        Lattitude = c.String(nullable: false, maxLength: 20),
                        Longitude = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Slogan = c.String(nullable: false, maxLength: 250),
                        ButtonText = c.String(nullable: false, maxLength: 50),
                        ButtonURL = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FAQs", "FaqCategory_ID", "dbo.FaqCategories");
            DropForeignKey("dbo.FAQs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProjectCategories", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.ProjectCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Blogs", "AuthorID", "dbo.Authors");
            DropIndex("dbo.FAQs", new[] { "FaqCategory_ID" });
            DropIndex("dbo.FAQs", new[] { "CategoryID" });
            DropIndex("dbo.ProjectCategories", new[] { "ProjectID" });
            DropIndex("dbo.ProjectCategories", new[] { "CategoryID" });
            DropIndex("dbo.Blogs", new[] { "CategoryID" });
            DropIndex("dbo.Blogs", new[] { "AuthorID" });
            DropTable("dbo.Sliders");
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.Partners");
            DropTable("dbo.FAQs");
            DropTable("dbo.FaqCategories");
            DropTable("dbo.Facts");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Blogs");
            DropTable("dbo.Authors");
            DropTable("dbo.Abouts");
        }
    }
}
