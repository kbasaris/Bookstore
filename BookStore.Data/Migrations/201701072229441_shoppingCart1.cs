namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shoppingCart1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShoppingCarts", "ItemId", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "TotalItems", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "ItemId");
            AddForeignKey("dbo.ShoppingCarts", "ItemId", "dbo.Item", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "ItemId", "dbo.Item");
            DropIndex("dbo.ShoppingCarts", new[] { "ItemId" });
            DropColumn("dbo.ShoppingCarts", "TotalItems");
            DropColumn("dbo.ShoppingCarts", "ItemId");
        }
    }
}
