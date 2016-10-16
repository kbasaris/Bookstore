namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stock", "ReorderAmount", c => c.Int());
            DropColumn("dbo.Stock", "ReeorderAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stock", "ReeorderAmount", c => c.Int());
            DropColumn("dbo.Stock", "ReorderAmount");
        }
    }
}
