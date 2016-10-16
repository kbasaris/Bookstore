namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceInBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Stock", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Book", "Price");
        }
    }
}
