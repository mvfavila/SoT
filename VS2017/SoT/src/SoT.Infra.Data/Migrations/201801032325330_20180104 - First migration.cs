namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20180104Firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Guid(nullable: false),
                        Street01 = c.String(nullable: false, maxLength: 300, unicode: false),
                        Complement = c.String(maxLength: 300, unicode: false),
                        Postcode = c.String(maxLength: 30, unicode: false),
                        AdventureId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            CreateTable(
                "dbo.Adventure",
                c => new
                    {
                        AdventureId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250, unicode: false),
                        CategoryId = c.Guid(nullable: false),
                        CityId = c.Guid(nullable: false),
                        AddressId = c.Guid(nullable: false),
                        InsurenceMinimalAmount = c.Decimal(precision: 9, scale: 2),
                        ProviderId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdventureId)
                .ForeignKey("dbo.Address", t => t.AddressId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.City", t => t.CityId)
                .ForeignKey("dbo.Provider", t => t.ProviderId)
                .Index(t => t.CategoryId)
                .Index(t => t.CityId)
                .Index(t => t.AddressId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        ElementId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Element", t => t.ElementId)
                .Index(t => t.ElementId);
            
            CreateTable(
                "dbo.Element",
                c => new
                    {
                        ElementId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ElementId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Country", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        CountryId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 70, unicode: false),
                        Active = c.Boolean(nullable: false),
                        RegionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Region", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Active = c.Boolean(nullable: false),
                        ContinentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.Continent", t => t.ContinentId)
                .Index(t => t.ContinentId);
            
            CreateTable(
                "dbo.Continent",
                c => new
                    {
                        ContinentId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 30, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ContinentId);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProviderId = c.Guid(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 400, unicode: false),
                        Active = c.Boolean(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProviderId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        GenderId = c.Guid(nullable: false),
                        ProviderId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.Provider", t => t.ProviderId)
                .Index(t => t.GenderId)
                .Index(t => t.ProviderId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        GenderId = c.Guid(nullable: false),
                        Value = c.String(nullable: false, maxLength: 30, unicode: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GenderId);
            
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
            DropForeignKey("dbo.Employee", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Employee", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Adventure", "ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Adventure", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "CountryId", "dbo.Country");
            DropForeignKey("dbo.Country", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Region", "ContinentId", "dbo.Continent");
            DropForeignKey("dbo.Adventure", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Category", "ElementId", "dbo.Element");
            DropForeignKey("dbo.Adventure", "AddressId", "dbo.Address");
            DropIndex("dbo.SubExample", new[] { "ExampleId" });
            DropIndex("dbo.Employee", new[] { "ProviderId" });
            DropIndex("dbo.Employee", new[] { "GenderId" });
            DropIndex("dbo.Region", new[] { "ContinentId" });
            DropIndex("dbo.Country", new[] { "RegionId" });
            DropIndex("dbo.City", new[] { "CountryId" });
            DropIndex("dbo.Category", new[] { "ElementId" });
            DropIndex("dbo.Adventure", new[] { "ProviderId" });
            DropIndex("dbo.Adventure", new[] { "AddressId" });
            DropIndex("dbo.Adventure", new[] { "CityId" });
            DropIndex("dbo.Adventure", new[] { "CategoryId" });
            DropTable("dbo.SubExample");
            DropTable("dbo.MenuItem");
            DropTable("dbo.Example");
            DropTable("dbo.Gender");
            DropTable("dbo.Employee");
            DropTable("dbo.Provider");
            DropTable("dbo.Continent");
            DropTable("dbo.Region");
            DropTable("dbo.Country");
            DropTable("dbo.City");
            DropTable("dbo.Element");
            DropTable("dbo.Category");
            DropTable("dbo.Adventure");
            DropTable("dbo.Address");
        }
    }
}
