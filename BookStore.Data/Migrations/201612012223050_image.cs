namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Image");
        }
    }
}
