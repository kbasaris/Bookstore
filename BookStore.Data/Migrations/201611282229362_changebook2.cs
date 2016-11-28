namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changebook2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Stock", newName: "Item");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Item", newName: "Stock");
        }
    }
}
