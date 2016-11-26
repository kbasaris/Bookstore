namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stock", "BookID", "dbo.Book");
            DropIndex("dbo.Stock", new[] { "BookID" });
            AlterColumn("dbo.Stock", "BookID", c => c.Int(nullable: false));
            AlterColumn("dbo.Stock", "Barcode", c => c.Int(nullable: false));
            AlterColumn("dbo.Stock", "Reorder", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Stock", "BookID");
            AddForeignKey("dbo.Stock", "BookID", "dbo.Book", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stock", "BookID", "dbo.Book");
            DropIndex("dbo.Stock", new[] { "BookID" });
            AlterColumn("dbo.Stock", "Reorder", c => c.Boolean());
            AlterColumn("dbo.Stock", "Barcode", c => c.Int());
            AlterColumn("dbo.Stock", "BookID", c => c.Int());
            CreateIndex("dbo.Stock", "BookID");
            AddForeignKey("dbo.Stock", "BookID", "dbo.Book", "Id");
        }
    }
}
