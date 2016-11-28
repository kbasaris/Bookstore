namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changebook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "Price", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Stock", "NumOfStocks", c => c.Int());
            DropColumn("dbo.Book", "Price");
            DropColumn("dbo.Book", "NumOfStocks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "NumOfStocks", c => c.Int());
            AddColumn("dbo.Book", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Stock", "NumOfStocks");
            DropColumn("dbo.Stock", "Price");
        }
    }
}
