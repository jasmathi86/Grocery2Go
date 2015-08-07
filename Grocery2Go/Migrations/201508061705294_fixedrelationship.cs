namespace Grocery2Go.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.Orders", new[] { "ShoppingCartId" });
            DropIndex("dbo.ShoppingCarts", new[] { "UserId" });
            AddColumn("dbo.AspNetUsers", "ShoppingCartId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "ShoppingCartId");
            AddForeignKey("dbo.AspNetUsers", "ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId", cascadeDelete: true);
            DropColumn("dbo.Orders", "ShoppingCartId");
            DropColumn("dbo.ShoppingCarts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "ShoppingCartId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "ShoppingCartId", "dbo.ShoppingCarts");
            DropIndex("dbo.AspNetUsers", new[] { "ShoppingCartId" });
            DropColumn("dbo.AspNetUsers", "ShoppingCartId");
            CreateIndex("dbo.ShoppingCarts", "UserId");
            CreateIndex("dbo.Orders", "ShoppingCartId");
            AddForeignKey("dbo.Orders", "ShoppingCartId", "dbo.ShoppingCarts", "ShoppingCartId", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingCarts", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
