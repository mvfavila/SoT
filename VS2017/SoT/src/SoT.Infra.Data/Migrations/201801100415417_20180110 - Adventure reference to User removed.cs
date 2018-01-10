namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180110AdventurereferencetoUserremoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adventure", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adventure", "UserId", c => c.Guid(nullable: false));
        }
    }
}
