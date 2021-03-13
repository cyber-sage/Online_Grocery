namespace Online_Grocery_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "categoryName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "categoryName", c => c.Int(nullable: false));
        }
    }
}
