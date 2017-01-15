namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingcart6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "UserId");
        }
    }
}
