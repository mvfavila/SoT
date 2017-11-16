namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdentityContextremoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employee", "User_Id", "dbo.User");
            DropIndex("dbo.Employee", new[] { "User_Id" });
            DropColumn("dbo.Employee", "User_Id");
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 100, unicode: false),
                        SecurityStamp = c.String(maxLength: 100, unicode: false),
                        PhoneNumber = c.String(maxLength: 100, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Employee", "User_Id", c => c.String(maxLength: 100, unicode: false));
            CreateIndex("dbo.Employee", "User_Id");
            AddForeignKey("dbo.Employee", "User_Id", "dbo.User", "Id");
        }
    }
}
