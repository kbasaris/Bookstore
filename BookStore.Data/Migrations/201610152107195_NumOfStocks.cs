namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumOfStocks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "NumOfStocks", c => c.Int());
            DropColumn("dbo.Stock", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "Stock", c => c.Int());
            DropColumn("dbo.Stock", "NumOfStocks");
        }
    }
}
