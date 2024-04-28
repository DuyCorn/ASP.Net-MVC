namespace DoAn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeCartItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "Product_ProductID", "dbo.Products");
            DropIndex("dbo.CartItems", new[] { "Product_ProductID" });
            DropTable("dbo.CartItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        CartId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Product_ProductID = c.Long(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            CreateIndex("dbo.CartItems", "Product_ProductID");
            AddForeignKey("dbo.CartItems", "Product_ProductID", "dbo.Products", "ProductID");
        }
    }
}
