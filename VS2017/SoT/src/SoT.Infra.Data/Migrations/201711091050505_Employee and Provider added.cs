namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeandProvideradded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, unicode: false),
                        BirthDate = c.DateTime(nullable: false),
                        ProviderId = c.Guid(nullable: false),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provider", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
            AddColumn("dbo.Provider", "RegisterDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Provider", "Email");
            DropColumn("dbo.Provider", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provider", "Name", c => c.String(nullable: false, maxLength: 400, unicode: false));
            AddColumn("dbo.Provider", "Email", c => c.String(nullable: false, maxLength: 150, unicode: false));
            DropForeignKey("dbo.Employee", "ProviderId", "dbo.Provider");
            DropIndex("dbo.Employee", new[] { "ProviderId" });
            DropColumn("dbo.Provider", "RegisterDate");
            DropTable("dbo.Employee");
        }
    }
}
