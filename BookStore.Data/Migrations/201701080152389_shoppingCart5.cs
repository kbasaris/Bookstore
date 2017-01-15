namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCart5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "CartId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShoppingCarts", "CartId");
        }
    }
}
