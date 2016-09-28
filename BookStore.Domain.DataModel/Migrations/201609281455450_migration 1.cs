namespace BookStore.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IsbnQuantities", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.IsbnQuantities", new[] { "Cart_Id" });
            DropPrimaryKey("dbo.Carts");
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        BookId = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                        Book_ISBN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Books", t => t.Book_ISBN)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.Book_ISBN);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Total = c.Single(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Carts", "RecordId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Carts", "CartId", c => c.String());
            AddColumn("dbo.Carts", "BookId", c => c.String());
            AddColumn("dbo.Carts", "Count", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Carts", "Book_ISBN", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Carts", "RecordId");
            CreateIndex("dbo.Carts", "Book_ISBN");
            AddForeignKey("dbo.Carts", "Book_ISBN", "dbo.Books", "ISBN");
            DropColumn("dbo.Carts", "Id");
            DropColumn("dbo.Carts", "clientId");
            DropTable("dbo.IsbnQuantities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IsbnQuantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false),
                        quantity = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Carts", "clientId", c => c.Int(nullable: false));
            AddColumn("dbo.Carts", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Book_ISBN", "dbo.Books");
            DropForeignKey("dbo.Carts", "Book_ISBN", "dbo.Books");
            DropIndex("dbo.OrderDetails", new[] { "Book_ISBN" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Carts", new[] { "Book_ISBN" });
            DropPrimaryKey("dbo.Carts");
            DropColumn("dbo.Carts", "Book_ISBN");
            DropColumn("dbo.Carts", "DateCreated");
            DropColumn("dbo.Carts", "Count");
            DropColumn("dbo.Carts", "BookId");
            DropColumn("dbo.Carts", "CartId");
            DropColumn("dbo.Carts", "RecordId");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            AddPrimaryKey("dbo.Carts", "Id");
            CreateIndex("dbo.IsbnQuantities", "Cart_Id");
            AddForeignKey("dbo.IsbnQuantities", "Cart_Id", "dbo.Carts", "Id");
        }
    }
}
