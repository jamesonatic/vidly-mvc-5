namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Movies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Movies", t => t.Movies_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Movies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
