namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRental : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies");
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            AlterColumn("dbo.Rentals", "Timestamp", c => c.DateTime());
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Rentals", "Movies_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "Customer_Id");
            CreateIndex("dbo.Rentals", "Movies_Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            DropIndex("dbo.Rentals", new[] { "Customer_Id" });
            AlterColumn("dbo.Rentals", "Movies_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Rentals", "Timestamp", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Rentals", "Movies_Id");
            CreateIndex("dbo.Rentals", "Customer_Id");
            AddForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Rentals", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
