namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180103 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employee", "GenderId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Employee", "GenderId");
            AddForeignKey("dbo.Employee", "GenderId", "dbo.Gender", "GenderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "GenderId", "dbo.Gender");
            DropIndex("dbo.Employee", new[] { "GenderId" });
            DropColumn("dbo.Employee", "GenderId");
        }
    }
}
