namespace DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unknown : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_ProductID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_ProductID" });
            DropTable("dbo.Carts");
        }
    }
}
