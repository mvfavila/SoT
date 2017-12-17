namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20171217Genderentityadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderId = c.Guid(nullable: false),
                        Value = c.String(nullable: false, maxLength: 30, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GenderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gender");
        }
    }
}
