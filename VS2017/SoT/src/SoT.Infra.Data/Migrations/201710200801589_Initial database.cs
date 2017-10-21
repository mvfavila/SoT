namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Example",
                c => new
                    {
                        ExampleId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250, unicode: false),
                        DatePropertyName = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExampleId);
            
            CreateTable(
                "dbo.SubExample",
                c => new
                    {
                        SubExampleId = c.Guid(nullable: false),
                        StringPropertyName = c.String(nullable: false, maxLength: 150, unicode: false),
                        SubExampleDatePropertyName = c.DateTime(nullable: false),
                        ExampleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.SubExampleId)
                .ForeignKey("dbo.Example", t => t.ExampleId)
                .Index(t => t.ExampleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubExample", "ExampleId", "dbo.Example");
            DropIndex("dbo.SubExample", new[] { "ExampleId" });
            DropTable("dbo.SubExample");
            DropTable("dbo.Example");
        }
    }
}
