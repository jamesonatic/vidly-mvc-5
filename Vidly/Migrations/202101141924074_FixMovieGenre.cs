namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMovieGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));


            Sql("UPDATE Movies SET Stock = 1 WHERE Id = 3002;");
            Sql("UPDATE Movies SET Stock = 5 WHERE Id = 3003;");
            Sql("UPDATE Movies SET Stock = 3 WHERE Id = 3004;");


            Sql("INSERT INTO Movies (Name, Genre_Id, DateAdded, DateRelease, Stock) VALUES ('Selector', " +
                "(SELECT Id " +
                " FROM Genres " +
                " WHERE Name = 'Thriller') , " + "   '2021-05-05',  '2010-01-01', 5)");
        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "Stock");
        }
    }
}
