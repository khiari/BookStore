namespace BookStore.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 10),
                        shortBio = c.String(nullable: false, maxLength: 300),
                        Book_ISBN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_ISBN)
                .Index(t => t.Book_ISBN);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ISBN = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false, maxLength: 10),
                        genre = c.String(nullable: false, maxLength: 10),
                        description = c.String(nullable: false, maxLength: 300),
                        price = c.Single(nullable: false),
                        editor = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ISBN);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        rating = c.Int(nullable: false),
                        review = c.String(nullable: false, maxLength: 300),
                        Book_ISBN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_ISBN)
                .Index(t => t.Book_ISBN);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        clientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IsbnQuantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false),
                        quantity = c.Int(nullable: false),
                        Cart_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .Index(t => t.Cart_Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fullName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IsbnQuantities", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Reviews", "Book_ISBN", "dbo.Books");
            DropForeignKey("dbo.Authors", "Book_ISBN", "dbo.Books");
            DropIndex("dbo.IsbnQuantities", new[] { "Cart_Id" });
            DropIndex("dbo.Reviews", new[] { "Book_ISBN" });
            DropIndex("dbo.Authors", new[] { "Book_ISBN" });
            DropTable("dbo.Clients");
            DropTable("dbo.IsbnQuantities");
            DropTable("dbo.Carts");
            DropTable("dbo.Reviews");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
