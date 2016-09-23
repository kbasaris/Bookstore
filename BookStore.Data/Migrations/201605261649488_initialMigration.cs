namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Author = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(),
                        Barcode = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Reorder = c.Boolean(),
                        ReeorderAmount = c.Int(),
                        Stock = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Book", t => t.BookID)
                .Index(t => t.BookID);
            
            CreateTable(
                "dbo.sysdiagrams",
                c => new
                    {
                        diagram_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 128),
                        principal_id = c.Int(nullable: false),
                        version = c.Int(),
                        definition = c.Binary(),
                    })
                .PrimaryKey(t => t.diagram_id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 100),
                        Password = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        LastActivity = c.DateTime(),
                        PostalAddress = c.String(maxLength: 50),
                        Name = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        LoggedIn = c.Boolean(),
                        Role = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stock", "BookID", "dbo.Book");
            DropIndex("dbo.Stock", new[] { "BookID" });
            DropTable("dbo.User");
            DropTable("dbo.sysdiagrams");
            DropTable("dbo.Stock");
            DropTable("dbo.Book");
        }
    }
}
