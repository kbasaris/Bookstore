namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _32435 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingCarts", "UserId", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingCarts", "UserId", c => c.String());
        }
    }
}
