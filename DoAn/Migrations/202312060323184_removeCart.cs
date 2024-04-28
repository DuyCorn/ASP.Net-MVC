namespace DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCart : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "Product_ProductID" });
            DropTable("dbo.Carts");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Carts", "Product_ProductID");
            AddForeignKey("dbo.Carts", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
