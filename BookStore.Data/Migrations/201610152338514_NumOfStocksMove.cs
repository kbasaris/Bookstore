namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumOfStocksMove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "NumOfStocks", c => c.Int());
            DropColumn("dbo.Stock", "NumOfStocks");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "NumOfStocks", c => c.Int());
            DropColumn("dbo.Book", "NumOfStocks");
        }
    }
}
