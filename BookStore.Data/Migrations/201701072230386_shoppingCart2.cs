namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCart2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "DateCreated");
        }
    }
}
