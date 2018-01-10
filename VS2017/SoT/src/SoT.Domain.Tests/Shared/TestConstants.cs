using SoT.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Tests.Shared
{
    public static class TestConstants
    {
        internal static readonly Guid GENDER_ID_VALID = Guid.Parse("2107891b-659f-4e04-9d3f-676e58e2661b");
        internal static readonly Guid GENDER_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string GENDER_VALUE_VALID = "Female";
        internal static readonly string GENDER_VALUE_INVALID_NULL;
        internal static readonly string GENDER_VALUE_INVALID_EMPTY = "";
        internal static readonly string GENDER_VALUE_INVALID_EMPTY_SPACES = " ";
        internal static readonly string GENDER_VALUE_VALID_LENGTH_EDGE = new string('A', 30);
        internal static readonly string GENDER_VALUE_INVALID_LENGTH = new string('A', 31);

        internal static readonly Guid ADDRESS_ID_VALID = Guid.Parse("f008f005-b1ac-4d3b-8d51-01235e2c50e5");
        internal static readonly Guid ADDRESS_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string STREET01_VALID = "Challinor St.";
        internal static readonly string STREET01_INVALID_NULL;
        internal static readonly string STREET01_INVALID_EMPTY = "";
        internal static readonly string STREET01_INVALID_EMPTY_SPACES = " ";
        internal static readonly string STREET01_VALID_LENGTH_EDGE = new string('A', 300);
        internal static readonly string STREET01_INVALID_LENGTH = new string('A', 301);

        internal static readonly string COMPLEMENT_VALID = "Close to the T junction";
        internal static readonly string COMPLEMENT_VALID_NULL;
        internal static readonly string COMPLEMENT_VALID_LENGTH_EDGE = new string('A', 300);
        internal static readonly string COMPLEMENT_INVALID_LENGTH = new string('A', 301);

        internal static readonly string POSTCODE_VALID = "49042-510";
        internal static readonly string POSTCODE_VALID_NULL;
        internal static readonly string POSTCODE_VALID_EDGE = new string('A', 30);
        internal static readonly string POSTCODE_INVALID_LENGTH = new string('A', 31);

        internal static readonly Guid ADVENTURE_ID_VALID = Guid.Parse("08f1e473-016d-46ef-8393-5b806c3752fe");
        internal static readonly Guid ADVENTURE_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string ADVENTURE_NAME_VALID = "Kayaking with the wales in Lisbon";
        internal static readonly string ADVENTURE_NAME_INVALID_NULL;
        internal static readonly string ADVENTURE_NAME_INVALID_EMPTY = "";
        internal static readonly string ADVENTURE_NAME_INVALID_EMPTY_SPACES = " ";
        internal static readonly string ADVENTURE_NAME_VALID_LENGTH_EDGE = new string('A', 250);
        internal static readonly string ADVENTURE_NAME_INVALID_LENGTH = new string('A', 251);

        internal static readonly Guid CATEGORY_ID_VALID = Guid.Parse("f911ed32-bd96-4c40-af77-45d2419c09f9");
        internal static readonly Guid CATEGORY_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string CATEGORY_NAME_VALID = "Kayaking";
        internal static readonly string CATEGORY_NAME_INVALID_NULL;
        internal static readonly string CATEGORY_NAME_INVALID_EMPTY = "";
        internal static readonly string CATEGORY_NAME_INVALID_EMPTY_SPACES = " ";
        internal static readonly string CATEGORY_NAME_VALID_LENGTH_EDGE = new string('A', 100);
        internal static readonly string CATEGORY_NAME_INVALID_LENGTH = new string('A', 101);

        internal static readonly Guid ELEMENT_ID_VALID = Guid.Parse("f0b9bcfb-3c20-4c89-a3a0-082f3a57590c");

        internal static readonly string ELEMENT_NAME_VALID = "Water";

        internal static readonly Element ELEMENT_VALID = Element.FactoryTest(
            ELEMENT_ID_VALID,
            ELEMENT_NAME_VALID,
            ACTIVE
            );

        internal static readonly Category CATEGORY_VALID = null;

        internal static readonly Guid CONTINENT_ID_VALID = Guid.Parse("843c9105-77b1-4a54-97f3-28a0ce797358");
        internal static readonly Guid CONTINENT_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly Continent CONTINENT_VALID = null;

        internal static readonly Guid REGION_ID_VALID = Guid.Parse("4f30cc60-f482-4fa9-8318-503e047276b4");
        internal static readonly Guid REGION_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string REGION_NAME_VALID = "Westesrn europe";
        internal static readonly string REGION_NAME_INVALID_NULL;
        internal static readonly string REGION_NAME_INVALID_EMPTY = "";
        internal static readonly string REGION_NAME_INVALID_EMPTY_SPACES = " ";
        internal static readonly string REGION_NAME_VALID_LENGTH_EDGE = new string('A', 100);
        internal static readonly string REGION_NAME_INVALID_LENGTH = new string('A', 101);

        internal static readonly Region REGION_VALID = null;

        internal static readonly Guid COUNTRY_ID_VALID = Guid.Parse("4ec1c433-acdc-4647-9a12-de664aa003e6");
        internal static readonly Guid COUNTRY_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string COUNTRY_NAME_VALID = "Lisbon";
        internal static readonly string COUNTRY_NAME_INVALID_NULL;
        internal static readonly string COUNTRY_NAME_INVALID_EMPTY = "";
        internal static readonly string COUNTRY_NAME_INVALID_EMPTY_SPACES = " ";
        internal static readonly string COUNTRY_NAME_VALID_LENGTH_EDGE = new string('A', 70);
        internal static readonly string COUNTRY_NAME_INVALID_LENGTH = new string('A', 71);

        internal static readonly Country COUNTRY_VALID = null;

        internal static readonly Guid CITY_ID_VALID = Guid.Parse("0f1b497c-d943-4334-bf64-bb3bd9b2047c");
        internal static readonly Guid CITY_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string CITY_NAME_VALID = "Lisbon";
        internal static readonly string CITY_NAME_INVALID_NULL;
        internal static readonly string CITY_NAME_INVALID_EMPTY = "";
        internal static readonly string CITY_NAME_INVALID_EMPTY_SPACES = " ";
        internal static readonly string CITY_NAME_VALID_LENGTH_EDGE = new string('A', 100);
        internal static readonly string CITY_NAME_INVALID_LENGTH = new string('A', 101);

        internal static readonly City CITY_VALID = null;

        internal static readonly decimal? INSURANCE_MINIMAL_VALID = 1.23M;
        internal static readonly decimal? INSURANCE_MINIMAL_VALID_NULL;
        internal static readonly decimal? INSURANCE_MINIMAL_INVALID_NEGATIVE = -0.01M;
        internal static readonly decimal? INSURANCE_MINIMAL_VALID_EDGE = 9999999.99M;
        internal static readonly decimal? INSURANCE_MINIMAL_INVALID_HIGHER_THAN_MAX_VALUE =
            INSURANCE_MINIMAL_VALID_EDGE + 0.01M;
        internal static readonly decimal? INSURANCE_MINIMAL_VALID_NO_DECIMAL_PLACES = 123M;
        internal static readonly decimal? INSURANCE_MINIMAL_VALID_ONE_DECIMAL_PLACES = 1.2M;
        internal static readonly decimal? INSURANCE_MINIMAL_VALID_TWO_DECIMAL_PLACES = 1.23M;
        internal static readonly decimal? INSURANCE_MINIMAL_INVALID_THREE_DECIMAL_PLACES = 1.234M;

        internal static readonly Guid EMPLOYEE_ID_VALID = Guid.Parse("6ade1b3f-dcec-4364-a191-a62278c3094f");
        internal static readonly Guid EMPLOYEE_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly DateTime EMPLOYEE_DATE_OF_BIRTH_VALID = DateTime.Today.AddYears(-30);
        internal static readonly DateTime EMPLOYEE_DATE_OF_BIRTH_VALID_EDGE = DateTime.Today.AddYears(-18);
        internal static readonly DateTime EMPLOYEE_DATE_OF_BIRTH_INVALID = DateTime.Today.AddYears(-18).AddDays(1);

        internal static readonly Employee EMPLOYEE_VALID = Employee.FactoryTest(EMPLOYEE_ID_VALID,
            EMPLOYEE_DATE_OF_BIRTH_VALID, GENDER_ID_VALID, PROVIDER_ID_VALID, null, USER_ID_VALID);

        internal static readonly Guid PROVIDER_ID_VALID = Guid.Parse("53135957-c223-4c80-8104-c0e25afc8d8c");
        internal static readonly Guid PROVIDER_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly string PROVIDER_COMPANY_NAME_VALID = "Lisbon";
        internal static readonly string PROVIDER_COMPANY_NAME_INVALID_NULL;
        internal static readonly string PROVIDER_COMPANY_NAME_INVALID_EMPTY = "";
        internal static readonly string PROVIDER_COMPANY_NAME_INVALID_EMPTY_SPACES = " ";
        internal static readonly string PROVIDER_COMPANY_NAME_VALID_LENGTH_EDGE = new string('A', 400);
        internal static readonly string PROVIDER_COMPANY_NAME_INVALID_LENGTH = new string('A', 401);

        internal static readonly ICollection<Adventure> PROVIDER_ADVENTURES_VALID = new List<Adventure>
        {
            null
        };

        internal static readonly ICollection<Employee> PROVIDER_EMPLOYEES_VALID = new List<Employee>
        {
            EMPLOYEE_VALID
        };
        internal static readonly ICollection<Employee> PROVIDER_EMPLOYEES_INVALID_NULL = null;
        internal static readonly ICollection<Employee> PROVIDER_EMPLOYEES_INVALID_EMPTY = new List<Employee>();

        internal static readonly Provider PROVIDER_VALID = null;

        internal static readonly List<Availability> AVAILABILITIES_VALID = new List<Availability>
        {
            null
        };

        internal static readonly Guid USER_ID_VALID = Guid.Parse("2f3b2f1d-a8c5-4a3a-a468-7e2940a0095c");
        internal static readonly Guid USER_ID_INVALID = Guid.Parse("00000000-0000-0000-0000-000000000000");

        internal static readonly bool ACTIVE = true;

        internal static readonly Adventure ADVENTURE_VALID = Adventure.FactoryTest(
            ADVENTURE_ID_VALID,
            ADVENTURE_NAME_VALID,
            CATEGORY_ID_VALID,
            CATEGORY_VALID,
            CITY_ID_VALID,
            CITY_VALID,
            ADDRESS_ID_VALID,
            null,
            INSURANCE_MINIMAL_VALID,
            PROVIDER_ID_VALID,
            PROVIDER_VALID,
            AVAILABILITIES_VALID,
            ACTIVE
            );

        internal static readonly Address ADDRESS_VALID = Address.FactoryTest(
            ADDRESS_ID_VALID,
            STREET01_VALID,
            COMPLEMENT_VALID,
            POSTCODE_VALID,
            ADVENTURE_ID_VALID
            );
    }
}
