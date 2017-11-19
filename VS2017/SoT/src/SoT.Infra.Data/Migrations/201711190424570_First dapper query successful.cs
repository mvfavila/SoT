namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstdapperquerysuccessful : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adventure", "Provider_ProviderId", c => c.Guid());
            AddColumn("dbo.Category", "Element_ElementId", c => c.Guid());
            AddColumn("dbo.City", "Country_CountryId", c => c.Guid());
            AddColumn("dbo.Country", "Region_RegionId", c => c.Guid());
            AddColumn("dbo.Region", "Continent_ContinentId", c => c.Guid());
            AddColumn("dbo.Employee", "Provider_ProviderId", c => c.Guid());
            AddColumn("dbo.SubExample", "Example_ExampleId", c => c.Guid());
            CreateIndex("dbo.Adventure", "Provider_ProviderId");
            CreateIndex("dbo.Category", "Element_ElementId");
            CreateIndex("dbo.City", "Country_CountryId");
            CreateIndex("dbo.Country", "Region_RegionId");
            CreateIndex("dbo.Region", "Continent_ContinentId");
            CreateIndex("dbo.Employee", "Provider_ProviderId");
            CreateIndex("dbo.SubExample", "Example_ExampleId");
            AddForeignKey("dbo.Category", "Element_ElementId", "dbo.Element", "ElementId");
            AddForeignKey("dbo.City", "Country_CountryId", "dbo.Country", "CountryId");
            AddForeignKey("dbo.Region", "Continent_ContinentId", "dbo.Continent", "ContinentId");
            AddForeignKey("dbo.Country", "Region_RegionId", "dbo.Region", "RegionId");
            AddForeignKey("dbo.Adventure", "Provider_ProviderId", "dbo.Provider", "ProviderId");
            AddForeignKey("dbo.Employee", "Provider_ProviderId", "dbo.Provider", "ProviderId");
            AddForeignKey("dbo.SubExample", "Example_ExampleId", "dbo.Example", "ExampleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubExample", "Example_ExampleId", "dbo.Example");
            DropForeignKey("dbo.Employee", "Provider_ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Adventure", "Provider_ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Country", "Region_RegionId", "dbo.Region");
            DropForeignKey("dbo.Region", "Continent_ContinentId", "dbo.Continent");
            DropForeignKey("dbo.City", "Country_CountryId", "dbo.Country");
            DropForeignKey("dbo.Category", "Element_ElementId", "dbo.Element");
            DropIndex("dbo.SubExample", new[] { "Example_ExampleId" });
            DropIndex("dbo.Employee", new[] { "Provider_ProviderId" });
            DropIndex("dbo.Region", new[] { "Continent_ContinentId" });
            DropIndex("dbo.Country", new[] { "Region_RegionId" });
            DropIndex("dbo.City", new[] { "Country_CountryId" });
            DropIndex("dbo.Category", new[] { "Element_ElementId" });
            DropIndex("dbo.Adventure", new[] { "Provider_ProviderId" });
            DropColumn("dbo.SubExample", "Example_ExampleId");
            DropColumn("dbo.Employee", "Provider_ProviderId");
            DropColumn("dbo.Region", "Continent_ContinentId");
            DropColumn("dbo.Country", "Region_RegionId");
            DropColumn("dbo.City", "Country_CountryId");
            DropColumn("dbo.Category", "Element_ElementId");
            DropColumn("dbo.Adventure", "Provider_ProviderId");
        }
    }
}
