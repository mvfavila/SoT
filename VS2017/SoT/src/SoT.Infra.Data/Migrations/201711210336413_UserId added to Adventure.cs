namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserIdaddedtoAdventure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adventure", "UserId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adventure", "UserId");
        }
    }
}
