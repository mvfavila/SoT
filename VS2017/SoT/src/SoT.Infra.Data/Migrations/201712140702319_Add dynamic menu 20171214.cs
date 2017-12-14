namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adddynamicmenu20171214 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItem",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        ActionName = c.String(maxLength: 50, unicode: false),
                        ControllerName = c.String(maxLength: 50, unicode: false),
                        Url = c.String(maxLength: 400, unicode: false),
                        ClaimType = c.String(maxLength: 50, unicode: false),
                        ClaimValue = c.String(maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MenuItem");
        }
    }
}
