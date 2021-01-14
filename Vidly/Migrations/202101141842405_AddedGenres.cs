namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "DateRelease", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");


            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");

            Sql("INSERT INTO Movies (Name, Genre_Id, DateAdded, DateRelease) VALUES ('Shrek',    1, '2007-01-01',  '2000-10-10')");
            Sql("INSERT INTO Movies (Name, Genre_Id, DateAdded, DateRelease) VALUES ('Champion', 2, '2020-01-01',  '2019-11-11')");
            Sql("INSERT INTO Movies (Name, Genre_Id, DateAdded, DateRelease) VALUES ('Winner',   2, GETDATE(), '1999-07-08')");


        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "DateRelease");
            DropColumn("dbo.Movies", "DateAdded");
            DropTable("dbo.Genres");
        }
    }
}
