namespace BookStore.Domain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "CartId", c => c.String());
            AddColumn("dbo.Carts", "BookId", c => c.String());
            AddColumn("dbo.OrderDetails", "BookId", c => c.String());
            DropColumn("dbo.Carts", "Cart_id");
            DropColumn("dbo.Carts", "Book_id");
            DropColumn("dbo.OrderDetails", "Book_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "Book_id", c => c.String());
            AddColumn("dbo.Carts", "Book_id", c => c.String());
            AddColumn("dbo.Carts", "Cart_id", c => c.String());
            DropColumn("dbo.OrderDetails", "BookId");
            DropColumn("dbo.Carts", "BookId");
            DropColumn("dbo.Carts", "CartId");
        }
    }
}
