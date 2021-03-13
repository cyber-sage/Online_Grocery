namespace Online_Grocery_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "userId", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookings", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Bookings", "userId");
        }
    }
}
