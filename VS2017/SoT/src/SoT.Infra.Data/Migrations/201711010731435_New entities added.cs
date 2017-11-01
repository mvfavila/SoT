namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Newentitiesadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        ElementId = c.Guid(nullable: false),
                        ValidationResult_Message = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Element", t => t.ElementId)
                .Index(t => t.ElementId);
            
            CreateTable(
                "dbo.Element",
                c => new
                    {
                        ElementId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ElementId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        CountryId = c.Guid(nullable: false),
                        ValidationResult_Message = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        RegionId = c.Guid(nullable: false),
                        ValidationResult_Message = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Region", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        ContinentId = c.Guid(nullable: false),
                        ValidationResult_Message = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.Continent", t => t.ContinentId)
                .Index(t => t.ContinentId);
            
            CreateTable(
                "dbo.Continent",
                c => new
                    {
                        ContinentId = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContinentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Country", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Region", "ContinentId", "dbo.Continent");
            DropForeignKey("dbo.Category", "ElementId", "dbo.Element");
            DropIndex("dbo.Region", new[] { "ContinentId" });
            DropIndex("dbo.Country", new[] { "RegionId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropIndex("dbo.Category", new[] { "ElementId" });
            DropTable("dbo.Continent");
            DropTable("dbo.Region");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Element");
            DropTable("dbo.Category");
        }
    }
}
