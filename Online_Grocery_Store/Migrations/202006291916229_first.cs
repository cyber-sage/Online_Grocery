namespace Online_Grocery_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookedItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        productName = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        totalPrice = c.Double(nullable: false),
                        bookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bookings", t => t.bookingId, cascadeDelete: true)
                .Index(t => t.bookingId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        AmountPaid = c.Double(nullable: false),
                        BookingDate = c.DateTime(nullable: false),
                        timeID = c.Int(nullable: false),
                        Status = c.String(),
                        DeliveredDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.times", t => t.timeID, cascadeDelete: true)
                .Index(t => t.timeID);
            
            CreateTable(
                "dbo.times",
                c => new
                    {
                        timeid = c.Int(nullable: false, identity: true),
                        availableTime = c.String(),
                    })
                .PrimaryKey(t => t.timeid);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        cartId = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        productName = c.String(),
                        Quantity = c.Int(nullable: false),
                        price = c.Int(nullable: false),
                        totalPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cartId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        categoryName = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        productName = c.String(nullable: false),
                        cateID = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Categories", t => t.cateID, cascadeDelete: true)
                .Index(t => t.cateID);
            
            CreateTable(
                "dbo.userDatas",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.userId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "cateID", "dbo.Categories");
            DropForeignKey("dbo.BookedItems", "bookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "timeID", "dbo.times");
            DropIndex("dbo.Products", new[] { "cateID" });
            DropIndex("dbo.Bookings", new[] { "timeID" });
            DropIndex("dbo.BookedItems", new[] { "bookingId" });
            DropTable("dbo.userDatas");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
            DropTable("dbo.times");
            DropTable("dbo.Bookings");
            DropTable("dbo.BookedItems");
        }
    }
}
