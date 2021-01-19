namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'68e8b63d-7c13-4a5e-a2e3-bb5877d9aaf1', N'guest@vidly.com', 0, N'ALN5b0vsuFCwbK2XWfi/sSsCWzXG6MEMdCwUPOcTnh4hgafdl23QfKIU9Ej00G35Lg==', N'7e859e50-e422-4880-82e8-3454cf8844de', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'88c9fe19-d337-43ea-a43e-87012bf6196a', N'admin@vidly.com', 0, N'ABNexOmX9YA7jB/bnGCrrXWxDeVbcfu70k2A8K0Al5WQKrOJe6Ie8baXh//CAI75/g==', N'3706fdc2-6985-43c3-9c48-ba367625395b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'241005b5-9531-45d1-bc95-bb751c08452d', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'88c9fe19-d337-43ea-a43e-87012bf6196a', N'241005b5-9531-45d1-bc95-bb751c08452d')
");
        }
        
        public override void Down()
        {
        }
    }
}
