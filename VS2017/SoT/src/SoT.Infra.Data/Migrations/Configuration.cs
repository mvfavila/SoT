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
            // TODO: set to false before launch
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Context.SoTContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region Element
            var elementAir = Element.FactorySeed("7a1a3567-9cd5-41ff-8f17-e76bdc207f69", "Air", true);
            var elementLand = Element.FactorySeed("f07f9f0a-077f-4098-a1fd-c9aba7257bec", "Land", true);
            var elementWater = Element.FactorySeed("d494f74e-3591-4fbe-98ec-643981b25a49", "Water", true);

            context.Elements.AddOrUpdate(
                e => e.ElementId,
                elementAir,
                elementLand,
                elementWater
                );
            #endregion

            #region Category
            var categoryKayaking = Category.FactorySeed("862adb47-72e9-4b6e-a3dd-23e7cf23a6f2", "Kayaking", true, elementWater.ElementId);
            var categoryParachuting = Category.FactorySeed("b92370a4-995c-4de2-9230-671e9dbb3e69", "Parachuting", true, elementAir.ElementId);
            var categorySkyDiving = Category.FactorySeed("c3e99af2-97da-4804-99e3-120d49154992", "Sky Diving", true, elementAir.ElementId);

            context.Categories.AddOrUpdate(
                c => c.CategoryId,
                categoryKayaking,
                categoryParachuting,
                categorySkyDiving
                );
            #endregion

            #region Continent
            var continentAfrica = Continent.FactorySeed("f7549b60-d58d-45fb-9d7d-2a520dc50303", "Africa", false);
            var continentAntarctica = Continent.FactorySeed("6758e325-4b27-45c8-9d54-32a0740d1a28", "Antarctica", false);
            var continentAsia = Continent.FactorySeed("c76e3fc3-cff1-4555-98fe-b69dbf2029ab", "Asia", false);
            var continentCentralAmerica = Continent.FactorySeed("0de0f82e-5a86-41c6-918a-3b1a50feb71b", "Central America", false);
            var continentEurope = Continent.FactorySeed("ea4b6795-6004-4815-a1ad-f5be38be2de0", "Europe", true);
            var continentNorthAmerica = Continent.FactorySeed("c1a89b39-3585-45d5-93eb-442c60c3e267", "North America", false);
            var continentOceania = Continent.FactorySeed("72c27388-faf2-43c2-92c7-88617bb326b2", "Oceania", false);
            var continentSouthAmerica = Continent.FactorySeed("0fa42398-b5b9-478c-aec5-65cd230ac395", "South America", true);

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
            var regionCentralEurope = Region.FactorySeed("a6c0b258-0f36-4c81-a805-85b10ab72906", "Central Europe", false, continentEurope.ContinentId);
            var regionEasternEurope = Region.FactorySeed("2f1d2069-e303-4430-8a81-6685cdd7a14e", "Eastern Europe", true, continentEurope.ContinentId);
            var regionNorthernEurope = Region.FactorySeed("6ea76520-7696-4640-94ee-253ba708ea0d", "Northern Europe", false, continentEurope.ContinentId);
            var regionSouthernEurope = Region.FactorySeed("10957bc4-f7ba-4121-b9b6-4e9db2ffee7b", "Southern Europe", false, continentEurope.ContinentId);
            var regionWesternEurope = Region.FactorySeed("b356ccd2-8fd8-48df-8227-79aa24e51985", "Western Europe", true, continentEurope.ContinentId);

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
            var countryAlbania = Country.FactorySeed("4b8bc1f7-3186-43fd-9bbb-d135903e1a2f", "Albania", false, regionSouthernEurope.RegionId);
            var countryAndorra = Country.FactorySeed("e3e06677-19ba-4c84-a62c-dc776b4eba4e", "Andorra", false, regionWesternEurope.RegionId);
            var countryArmenia = Country.FactorySeed("c917ec9f-6759-4613-ba23-bb046f63eebb", "Armenia", false, regionCentralEurope.RegionId);
            var countryAustria = Country.FactorySeed("b6ab886d-2b34-47d3-a9a7-0e931d11854d", "Austria", false, regionCentralEurope.RegionId);
            var countryAzerbaijan = Country.FactorySeed("0a1f1efd-3aba-4cb2-beff-3fcedf33ef06", "Azerbaijan", false, regionCentralEurope.RegionId);
            // B
            var countryBelarus = Country.FactorySeed("0cd27b11-e3b5-4060-9193-2217cd42f71e", "Belarus", false, regionNorthernEurope.RegionId);
            var countryBelgium = Country.FactorySeed("5e28ed5b-2806-464f-a4f6-65b499ab9d4b", "Belgium", false, regionWesternEurope.RegionId);
            var countryBosniaAndHerzegovina = Country.FactorySeed("472d7563-f966-4a7a-b67f-ad6c46acd18e", "Bosnia and Herzegovina", false, regionCentralEurope.RegionId);
            var countryBulgaria = Country.FactorySeed("33a7160f-cef3-4ba5-b861-ab0e25c343b5", "Bulgaria", false, regionEasternEurope.RegionId);
            // C
            var countryCroatia = Country.FactorySeed("2f0608b4-1ab0-4b31-86fe-bd71f96f6aab", "Croatia", true, regionEasternEurope.RegionId);
            var countryCyprus = Country.FactorySeed("9014c0fb-bb6e-472a-93dd-65841e34b178", "Cyprus", false, regionEasternEurope.RegionId);
            var countryCzechRepublic = Country.FactorySeed("e3c74b2e-ef8f-4cf5-aab9-719b0fb4bda0", "Czech Republic", false, regionEasternEurope.RegionId);
            // D
            var countryDenmark = Country.FactorySeed("aa768b01-d935-4cc4-b340-f4d71bf2a56a", "Denmark", true, regionNorthernEurope.RegionId);
            // E
            var countryEngland = Country.FactorySeed("76ed4317-0b31-494e-a350-8a296b715ce9", "England", false, regionWesternEurope.RegionId);
            var countryEstonia = Country.FactorySeed("0f8886f7-3e34-4993-880f-0ac35c826f7f", "Estonia", false, regionNorthernEurope.RegionId);
            // F
            var countryFinland = Country.FactorySeed("39a71e26-656c-43bc-8080-11929c635e8c", "Finland", false, regionNorthernEurope.RegionId);
            var countryFrance = Country.FactorySeed("d78ac1db-b05f-49f9-af79-2e612fd3e8b6", "France", false, regionWesternEurope.RegionId);
            // G
            var countryGeorgia = Country.FactorySeed("1213c902-81e2-4f75-b8e5-28c8c8fbcaca", "Georgia", false, regionCentralEurope.RegionId);
            var countryGermany = Country.FactorySeed("bf9362c5-6a5f-49f7-a54c-b39290f7a41e", "Germany", false, regionNorthernEurope.RegionId);
            var countryGreece = Country.FactorySeed("55ef831c-c0fd-4f55-bee6-ef849ec306ab", "Greece", false, regionSouthernEurope.RegionId);
            // H
            var countryHungary = Country.FactorySeed("a14a9421-97fe-410f-bf2d-5f337171f614", "Hungary", false, regionEasternEurope.RegionId);
            // I
            var countryIceland = Country.FactorySeed("7b71d740-7957-4847-b1e4-3caf80278c8b", "Iceland", false, regionNorthernEurope.RegionId);
            var countryIreland = Country.FactorySeed("baa9f777-7c19-49ae-9975-e50341938186", "Ireland", false, regionWesternEurope.RegionId);
            var countryItaly = Country.FactorySeed("81df108d-d365-4c5a-b48e-8b5011c2798f", "Italy", false, regionSouthernEurope.RegionId);
            // K
            var countryKazakhstan = Country.FactorySeed("d84d9734-b415-456c-be1e-9162fd554772", "Kazakhstan", false, regionCentralEurope.RegionId);
            var countryKosovo = Country.FactorySeed("321d3b5a-b950-43be-bf0a-deddcdd64fdc", "Kosovo", false, regionCentralEurope.RegionId);
            // L
            var countryLatvia = Country.FactorySeed("8ee9ebce-b42f-495a-ac6b-63ecaa761aa3", "Latvia", false, regionNorthernEurope.RegionId);
            var countryLiechtenstein = Country.FactorySeed("4ca66aa4-b449-4227-b7ec-023f3106a8d8", "Hungary", false, regionCentralEurope.RegionId);
            var countryLithuania = Country.FactorySeed("5d4d2139-f756-48f7-bdb7-6498a2b1041d", "Hungary", false, regionEasternEurope.RegionId);
            var countryLuxembourg = Country.FactorySeed("f2bee7f8-e194-4648-94da-c2aac0b509bc", "Hungary", false, regionWesternEurope.RegionId);
            // M
            var countryMacedonia = Country.FactorySeed("66a8a20b-a42a-49f1-81c7-dd41fed1f1eb", "Macedonia", false, regionCentralEurope.RegionId);
            var countryMalta = Country.FactorySeed("82888c92-7ede-4117-9872-7d2c42762737", "Malta", false, regionSouthernEurope.RegionId);
            var countryMoldova = Country.FactorySeed("2935fe72-2b9a-466d-a4a5-2517acfb190d", "Moldova", false, regionCentralEurope.RegionId);
            var countryMonaco = Country.FactorySeed("c3504acf-3f9d-4967-a658-14b94a745066", "Monaco", false, regionWesternEurope.RegionId);
            var countryMontenegro = Country.FactorySeed("f6da11a2-11b9-43ee-87e8-d683c2b86e67", "Montenegro", true, regionSouthernEurope.RegionId);
            // N
            var countryNetherlands = Country.FactorySeed("8a8c5eec-8d3f-4464-8b75-5b7f7a1ec17a", "Netherlands", false, regionNorthernEurope.RegionId);
            var countryNorway = Country.FactorySeed("78651051-90a5-4bf3-8e97-969aa572fbf3", "Norway", false, regionCentralEurope.RegionId);
            // P
            var countryPoland = Country.FactorySeed("76da30af-462a-4f04-ad27-da25123100a9", "Poland", false, regionEasternEurope.RegionId);
            var countryPortugal = Country.FactorySeed("1e381788-6216-4fcb-a44f-70c4a28f30f6", "Portugal", true, regionWesternEurope.RegionId);
            // R
            var countryRomania = Country.FactorySeed("fab96f76-e8a7-410d-bcab-31d9aa78f9df", "Romania", false, regionEasternEurope.RegionId);
            var countryRussia = Country.FactorySeed("34846b84-a676-4e31-9eca-e7693dddaa83", "Russia", false, regionCentralEurope.RegionId);
            // S
            var countrySanMarino = Country.FactorySeed("044d6142-2b32-460e-a563-6b7f15563614", "San Marino", false, regionSouthernEurope.RegionId);
            var countryScotland = Country.FactorySeed("484c3ec1-7ab3-41bf-a02b-b6830ba07781", "Scotland", false, regionWesternEurope.RegionId);
            var countrySerbia = Country.FactorySeed("3db275f9-8e9d-4c34-82d8-f6d054c9a3a0", "Serbia", false, regionCentralEurope.RegionId);
            var countrySlovakia = Country.FactorySeed("f8cfe6de-7cba-4888-bf61-3889bd22595e", "Slovakia", false, regionEasternEurope.RegionId);
            var countrySlovenia = Country.FactorySeed("1203ddfe-7900-4f51-91dc-88b1fac41138", "Slovenia", false, regionEasternEurope.RegionId);
            var countrySpain = Country.FactorySeed("e871047a-a08c-4372-90e8-0b51e3a5264b", "Spain", true, regionWesternEurope.RegionId);
            var countrySweden = Country.FactorySeed("f2ac290d-0227-4730-9c13-c3e4919f589e", "Sweden", false, regionNorthernEurope.RegionId);
            var countrySwitzerland = Country.FactorySeed("4ec96efe-2f45-434a-abb4-553deeda2ae3", "Switzerland", false, regionCentralEurope.RegionId);
            // T
            var countryTurkey = Country.FactorySeed("070e2006-b38a-45f0-a785-00e147a74cb5", "Turkey", true, regionSouthernEurope.RegionId);
            // U
            var countryUkraine = Country.FactorySeed("af85ba89-87b1-4686-87b2-17763e6d5bc1", "Ukraine", false, regionCentralEurope.RegionId);
            // V
            var countryVaticanCity = Country.FactorySeed("f7a6c956-a700-41e7-8424-7c5e25e2ec9a", "Vatican City", false, regionSouthernEurope.RegionId);
            // W
            var countryWales = Country.FactorySeed("f2b8fa51-ba70-4abe-b6ad-8bb269e48d72", "Wales", false, regionWesternEurope.RegionId);

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
            var cityBerlin = City.FactorySeed("3bbd1522-8adb-4a31-9c33-ee11b5ec7999", "Berlin", true, countryGermany.CountryId);
            var cityLisbon = City.FactorySeed("cd68ee60-8169-4897-8337-c416e41980a8", "Lisbon", true, countryPortugal.CountryId);
            var cityPorto = City.FactorySeed("052e732f-7af3-4ea8-b4c7-429ef1cd4e7c", "Porto", true, countryPortugal.CountryId);
            var citySplit = City.FactorySeed("175be4c3-83a8-408a-81be-a762e8a0f773", "Split", true, countryCroatia.CountryId);

            context.Cities.AddOrUpdate(
                c => c.CityId,
                cityBerlin,
                cityLisbon,
                cityPorto,
                citySplit
                );
            #endregion

            #region Navigation - Menu
            var menuItemHome = MenuItem.FactorySeed("Home", "Index", "Home", null, null, null);
            var menuItemAdminClaims = MenuItem.FactorySeed("Claims", "Index", "ClaimsAdmin", null, "AdmClaims", "True");
            var menuItemManageProvider = MenuItem.FactorySeed("Provider", "Details", "Provider", null, "ManageProvider", "True");
            var menuItemAdmProvider = MenuItem.FactorySeed("Providers", "Manage", "Provider", null, "AdmProvider", "True");

            context.MenuItems.AddOrUpdate(
                m => m.Name,
                menuItemHome,
                menuItemAdminClaims,
                menuItemManageProvider,
                menuItemAdmProvider
                );
            #endregion
        }
    }
}
