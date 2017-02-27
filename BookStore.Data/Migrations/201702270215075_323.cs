namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _323 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingCarts", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingCarts", "UserId", c => c.Int(nullable: false));
        }
    }
}
