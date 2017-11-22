namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171123_922 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Address", "AdventureId", "dbo.Adventure");
            DropIndex("dbo.Address", new[] { "AdventureId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Address", "AdventureId");
            AddForeignKey("dbo.Address", "AdventureId", "dbo.Adventure", "AdventureId");
        }
    }
}
