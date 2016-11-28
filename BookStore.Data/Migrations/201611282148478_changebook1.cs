namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changebook1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Stock", "Barcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "Barcode", c => c.Int(nullable: false));
        }
    }
}
