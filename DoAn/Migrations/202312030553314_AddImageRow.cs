namespace DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageRow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Image");
        }
    }
}
