namespace SoT.Infra.Data.Migrations
{
    using SoT.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context.SoTContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.SoTContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region Element
            var elementAir = Element.FactoryAdd("Air");
            var elementLand = Element.FactoryAdd("Land");
            var elementWater = Element.FactoryAdd("Water");

            context.Elements.AddOrUpdate(
                e => e.ElementId,
                elementAir,
                elementLand,
                elementWater
                );
            #endregion

            #region Category
            var categoryKayaking = Category.FactoryAdd("Kayaking", elementWater.ElementId);
            var categoryParachuting = Category.FactoryAdd("Parachuting", elementAir.ElementId);
            var categorySkyDiving = Category.FactoryAdd("Sky Diving", elementAir.ElementId);

            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                categoryKayaking,
                categoryParachuting,
                categorySkyDiving
                );
            #endregion

            #region Continent
            var continentAfrica = Continent.FactoryAdd("Africa");
            var continentAntarctica = Continent.FactoryAdd("Antarctica");
            var continentAsia = Continent.FactoryAdd("Asia");
            var continentCentralAmerica = Continent.FactoryAdd("Central America");
            var continentEurope = Continent.FactoryAdd("Europe");
            var continentNorthAmerica = Continent.FactoryAdd("North America");
            var continentOceania = Continent.FactoryAdd("Oceania");
            var continentSouthAmerica = Continent.FactoryAdd("South America");

            context.Continents.AddOrUpdate(
                c => c.ContinentId,
                continentAfrica,
                continentAntarctica,
                continentAsia,
                continentCentralAmerica,
                continentEurope,
                continentNorthAmerica,
                continentOceania,
                continentSouthAmerica
                );
            #endregion

            #region Region
            var regionCentralEurope = Region.FactoryAdd("Central Europe", continentEurope.ContinentId);
            var regionEasternEurope = Region.FactoryAdd("Eastern Europe", continentEurope.ContinentId);
            var regionNorthernEurope = Region.FactoryAdd("Northern Europe", continentEurope.ContinentId);
            var regionSouthernEurope = Region.FactoryAdd("Southern Europe", continentEurope.ContinentId);
            var regionWesternEurope = Region.FactoryAdd("Western Europe", continentEurope.ContinentId);

            context.Regions.AddOrUpdate(
                r => r.RegionId,
                regionCentralEurope,
                regionEasternEurope,
                regionNorthernEurope,
                regionSouthernEurope,
                regionWesternEurope
                );
            #endregion

            #region Country
            // A
            var countryAlbania = Country.FactoryAdd("Albania", regionSouthernEurope.RegionId);
            var countryAndorra = Country.FactoryAdd("Andorra", regionWesternEurope.RegionId);
            var countryArmenia = Country.FactoryAdd("Armenia", regionCentralEurope.RegionId);
            var countryAustria = Country.FactoryAdd("Austria", regionCentralEurope.RegionId);
            var countryAzerbaijan = Country.FactoryAdd("Azerbaijan", regionCentralEurope.RegionId);
            // B
            var countryBelarus = Country.FactoryAdd("Belarus", regionNorthernEurope.RegionId);
            var countryBelgium = Country.FactoryAdd("Belgium", regionWesternEurope.RegionId);
            var countryBosniaAndHerzegovina = Country.FactoryAdd("Bosnia and Herzegovina", regionCentralEurope.RegionId);
            var countryBulgaria = Country.FactoryAdd("Bulgaria", regionEasternEurope.RegionId);
            // C
            var countryCroatia = Country.FactoryAdd("Croatia", regionEasternEurope.RegionId);
            var countryCyprus = Country.FactoryAdd("Cyprus", regionEasternEurope.RegionId);
            var countryCzechRepublic = Country.FactoryAdd("Czech Republic", regionEasternEurope.RegionId);
            // D
            var countryDenmark = Country.FactoryAdd("Denmark", regionNorthernEurope.RegionId);
            // E
            var countryEngland = Country.FactoryAdd("England", regionWesternEurope.RegionId);
            var countryEstonia = Country.FactoryAdd("Estonia", regionNorthernEurope.RegionId);
            // F
            var countryFinland = Country.FactoryAdd("Finland", regionNorthernEurope.RegionId);
            var countryFrance = Country.FactoryAdd("France", regionWesternEurope.RegionId);
            // G
            var countryGeorgia = Country.FactoryAdd("Georgia", regionCentralEurope.RegionId);
            var countryGermany = Country.FactoryAdd("Germany", regionNorthernEurope.RegionId);
            var countryGreece = Country.FactoryAdd("Greece", regionSouthernEurope.RegionId);
            // H
            var countryHungary = Country.FactoryAdd("Hungary", regionEasternEurope.RegionId);
            // I
            var countryIceland = Country.FactoryAdd("Iceland", regionNorthernEurope.RegionId);
            var countryIreland = Country.FactoryAdd("Ireland", regionWesternEurope.RegionId);
            var countryItaly = Country.FactoryAdd("Italy", regionSouthernEurope.RegionId);
            // K
            var countryKazakhstan = Country.FactoryAdd("Kazakhstan", regionCentralEurope.RegionId);
            var countryKosovo = Country.FactoryAdd("Kosovo", regionCentralEurope.RegionId);
            // L
            var countryLatvia = Country.FactoryAdd("Latvia", regionNorthernEurope.RegionId);
            var countryLiechtenstein = Country.FactoryAdd("Hungary", regionCentralEurope.RegionId);
            var countryLithuania = Country.FactoryAdd("Hungary", regionEasternEurope.RegionId);
            var countryLuxembourg = Country.FactoryAdd("Hungary", regionWesternEurope.RegionId);
            // M
            var countryMacedonia = Country.FactoryAdd("Macedonia", regionCentralEurope.RegionId);
            var countryMalta = Country.FactoryAdd("Malta", regionSouthernEurope.RegionId);
            var countryMoldova = Country.FactoryAdd("Moldova", regionCentralEurope.RegionId);
            var countryMonaco = Country.FactoryAdd("Monaco", regionWesternEurope.RegionId);
            var countryMontenegro = Country.FactoryAdd("Montenegro", regionSouthernEurope.RegionId);
            // N
            var countryNetherlands = Country.FactoryAdd("Netherlands", regionNorthernEurope.RegionId);
            var countryNorway = Country.FactoryAdd("Norway", regionCentralEurope.RegionId);
            // P
            var countryPoland = Country.FactoryAdd("Poland", regionEasternEurope.RegionId);
            var countryPortugal = Country.FactoryAdd("Portugal", regionWesternEurope.RegionId);
            // R
            var countryRomania = Country.FactoryAdd("Romania", regionEasternEurope.RegionId);
            var countryRussia = Country.FactoryAdd("Russia", regionCentralEurope.RegionId);
            // S
            var countrySanMarino = Country.FactoryAdd("San Marino", regionSouthernEurope.RegionId);
            var countryScotland = Country.FactoryAdd("Scotland", regionWesternEurope.RegionId);
            var countrySerbia = Country.FactoryAdd("Serbia", regionCentralEurope.RegionId);
            var countrySlovakia = Country.FactoryAdd("Slovakia", regionEasternEurope.RegionId);
            var countrySlovenia = Country.FactoryAdd("Slovenia", regionEasternEurope.RegionId);
            var countrySpain = Country.FactoryAdd("Spain", regionWesternEurope.RegionId);
            var countrySweden = Country.FactoryAdd("Sweden", regionNorthernEurope.RegionId);
            var countrySwitzerland = Country.FactoryAdd("Switzerland", regionCentralEurope.RegionId);
            // T
            var countryTurkey = Country.FactoryAdd("Turkey", regionSouthernEurope.RegionId);
            // U
            var countryUkraine = Country.FactoryAdd("Ukraine", regionCentralEurope.RegionId);
            // V
            var countryVaticanCity = Country.FactoryAdd("Vatican City", regionSouthernEurope.RegionId);
            // W
            var countryWales = Country.FactoryAdd("Wales", regionWesternEurope.RegionId);

            context.Countries.AddOrUpdate(
                c => c.CountryId,
                countryAlbania,
                countryAndorra,
                countryArmenia,
                countryAustria,
                countryAzerbaijan,
                countryBelarus,
                countryBelgium,
                countryBosniaAndHerzegovina,
                countryBulgaria,
                countryCroatia,
                countryCyprus,
                countryCzechRepublic,
                countryDenmark,
                countryEngland,
                countryEstonia,
                countryFinland,
                countryFrance,
                countryGeorgia,
                countryGermany,
                countryGreece,
                countryHungary,
                countryIceland,
                countryIreland,
                countryItaly,
                countryKazakhstan,
                countryKosovo,
                countryLatvia,
                countryLiechtenstein,
                countryLithuania,
                countryLuxembourg,
                countryMacedonia,
                countryMalta,
                countryMoldova,
                countryMonaco,
                countryMontenegro,
                countryNetherlands,
                countryNorway,
                countryPoland,
                countryPortugal,
                countryRomania,
                countryRussia,
                countrySanMarino,
                countryScotland,
                countrySerbia,
                countrySlovakia,
                countrySlovenia,
                countrySpain,
                countrySweden,
                countrySwitzerland,
                countryTurkey,
                countryUkraine,
                countryVaticanCity,
                countryWales
                );
            #endregion

            #region City
            var cityBerlin = City.FactoryAdd("Berlin", countryGermany.CountryId);
            var cityLisbon = City.FactoryAdd("Lisbon", countryPortugal.CountryId);
            var cityPorto = City.FactoryAdd("Porto", countryPortugal.CountryId);
            var citySplit = City.FactoryAdd("Split", countryCroatia.CountryId);

            context.Cities.AddOrUpdate(
                c => c.CityId,
                cityBerlin,
                cityLisbon,
                cityPorto,
                citySplit
                );
            #endregion
        }
    }
}
