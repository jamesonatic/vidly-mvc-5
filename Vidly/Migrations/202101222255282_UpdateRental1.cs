namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRental1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AddColumn("dbo.Rentals", "DateRented", c => c.DateTime(nullable: false));
            AddColumn("dbo.Rentals", "DateReturn", c => c.DateTime());
            DropColumn("dbo.Rentals", "Timestamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rentals", "Timestamp", c => c.DateTime());
            DropColumn("dbo.Rentals", "DateReturn");
            DropColumn("dbo.Rentals", "DateRented");
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
