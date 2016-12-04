namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ffff : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "Image", c => c.String());
        }
    }
}
