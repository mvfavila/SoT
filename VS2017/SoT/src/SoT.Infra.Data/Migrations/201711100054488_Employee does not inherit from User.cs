namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeedoesnotinheritfromUser : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employee");
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
            
            AddColumn("dbo.Employee", "EmployeeId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employee", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Employee", "User_Id", c => c.String(maxLength: 100, unicode: false));
            AddPrimaryKey("dbo.Employee", "EmployeeId");
            CreateIndex("dbo.Employee", "User_Id");
            AddForeignKey("dbo.Employee", "User_Id", "dbo.User", "Id");
            DropColumn("dbo.Employee", "Id");
            DropColumn("dbo.Employee", "Email");
            DropColumn("dbo.Employee", "EmailConfirmed");
            DropColumn("dbo.Employee", "PasswordHash");
            DropColumn("dbo.Employee", "SecurityStamp");
            DropColumn("dbo.Employee", "PhoneNumber");
            DropColumn("dbo.Employee", "PhoneNumberConfirmed");
            DropColumn("dbo.Employee", "TwoFactorEnabled");
            DropColumn("dbo.Employee", "LockoutEndDateUtc");
            DropColumn("dbo.Employee", "LockoutEnabled");
            DropColumn("dbo.Employee", "AccessFailedCount");
            DropColumn("dbo.Employee", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "UserName", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Employee", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.Employee", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.Employee", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "PhoneNumber", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Employee", "SecurityStamp", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Employee", "PasswordHash", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Employee", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employee", "Email", c => c.String(maxLength: 100, unicode: false));
            AddColumn("dbo.Employee", "Id", c => c.String(nullable: false, maxLength: 100, unicode: false));
            DropForeignKey("dbo.Employee", "User_Id", "dbo.User");
            DropIndex("dbo.Employee", new[] { "User_Id" });
            DropPrimaryKey("dbo.Employee");
            DropColumn("dbo.Employee", "User_Id");
            DropColumn("dbo.Employee", "UserId");
            DropColumn("dbo.Employee", "EmployeeId");
            DropTable("dbo.User");
            AddPrimaryKey("dbo.Employee", "Id");
        }
    }
}
