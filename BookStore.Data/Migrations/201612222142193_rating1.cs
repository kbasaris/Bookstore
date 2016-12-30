namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rating1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "TotalRaters", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "TotalRaters");
        }
    }
}
