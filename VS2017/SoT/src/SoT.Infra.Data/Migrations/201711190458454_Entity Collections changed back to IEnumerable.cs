namespace SoT.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityCollectionschangedbacktoIEnumerable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "Element_ElementId", "dbo.Element");
            DropForeignKey("dbo.City", "Country_CountryId", "dbo.Country");
            DropForeignKey("dbo.Region", "Continent_ContinentId", "dbo.Continent");
            DropForeignKey("dbo.Country", "Region_RegionId", "dbo.Region");
            DropForeignKey("dbo.Adventure", "Provider_ProviderId", "dbo.Provider");
            DropForeignKey("dbo.Employee", "Provider_ProviderId", "dbo.Provider");
            DropForeignKey("dbo.SubExample", "Example_ExampleId", "dbo.Example");
            DropIndex("dbo.Adventure", new[] { "Provider_ProviderId" });
            DropIndex("dbo.Category", new[] { "Element_ElementId" });
            DropIndex("dbo.City", new[] { "Country_CountryId" });
            DropIndex("dbo.Country", new[] { "Region_RegionId" });
            DropIndex("dbo.Region", new[] { "Continent_ContinentId" });
            DropIndex("dbo.Employee", new[] { "Provider_ProviderId" });
            DropIndex("dbo.SubExample", new[] { "Example_ExampleId" });
            DropColumn("dbo.Adventure", "Provider_ProviderId");
            DropColumn("dbo.Category", "Element_ElementId");
            DropColumn("dbo.City", "Country_CountryId");
            DropColumn("dbo.Country", "Region_RegionId");
            DropColumn("dbo.Region", "Continent_ContinentId");
            DropColumn("dbo.Employee", "Provider_ProviderId");
            DropColumn("dbo.SubExample", "Example_ExampleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubExample", "Example_ExampleId", c => c.Guid());
            AddColumn("dbo.Employee", "Provider_ProviderId", c => c.Guid());
            AddColumn("dbo.Region", "Continent_ContinentId", c => c.Guid());
            AddColumn("dbo.Country", "Region_RegionId", c => c.Guid());
            AddColumn("dbo.City", "Country_CountryId", c => c.Guid());
            AddColumn("dbo.Category", "Element_ElementId", c => c.Guid());
            AddColumn("dbo.Adventure", "Provider_ProviderId", c => c.Guid());
            CreateIndex("dbo.SubExample", "Example_ExampleId");
            CreateIndex("dbo.Employee", "Provider_ProviderId");
            CreateIndex("dbo.Region", "Continent_ContinentId");
            CreateIndex("dbo.Country", "Region_RegionId");
            CreateIndex("dbo.City", "Country_CountryId");
            CreateIndex("dbo.Category", "Element_ElementId");
            CreateIndex("dbo.Adventure", "Provider_ProviderId");
            AddForeignKey("dbo.SubExample", "Example_ExampleId", "dbo.Example", "ExampleId");
            AddForeignKey("dbo.Employee", "Provider_ProviderId", "dbo.Provider", "ProviderId");
            AddForeignKey("dbo.Adventure", "Provider_ProviderId", "dbo.Provider", "ProviderId");
            AddForeignKey("dbo.Country", "Region_RegionId", "dbo.Region", "RegionId");
            AddForeignKey("dbo.Region", "Continent_ContinentId", "dbo.Continent", "ContinentId");
            AddForeignKey("dbo.City", "Country_CountryId", "dbo.Country", "CountryId");
            AddForeignKey("dbo.Category", "Element_ElementId", "dbo.Element", "ElementId");
        }
    }
}
