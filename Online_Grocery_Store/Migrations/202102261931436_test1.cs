namespace Online_Grocery_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailTests",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        NameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.NameTests", t => t.NameID, cascadeDelete: true)
                .Index(t => t.NameID);
            
            CreateTable(
                "dbo.NameTests",
                c => new
                    {
                        NameID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.NameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailTests", "NameID", "dbo.NameTests");
            DropIndex("dbo.EmailTests", new[] { "NameID" });
            DropTable("dbo.NameTests");
            DropTable("dbo.EmailTests");
        }
    }
}
