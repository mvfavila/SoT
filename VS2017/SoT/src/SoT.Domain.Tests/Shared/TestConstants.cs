using SoT.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SoT.Domain.Tests.Shared
{
    public static class TestConstants
    {
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

        internal static readonly Category CATEGORY_VALID = null;

        internal static readonly Guid CITY_ID_VALID = Guid.Parse("0f1b497c-d943-4334-bf64-bb3bd9b2047c");

        internal static readonly City CITY_VALID = null;

        internal static readonly decimal? INSURANCE_MINIMAL_VALID = 1.23M;
        internal static readonly decimal? INSURANCE_MINIMAL_VALID_NULL;
        internal static readonly decimal? INSURANCE_MINIMAL_INVALID_NEGATIVE = -0.01M;

        internal static readonly Guid PROVIDER_ID_VALID = Guid.Parse("53135957-c223-4c80-8104-c0e25afc8d8c");

        internal static readonly Provider PROVIDER_VALID = null;

        internal static readonly List<Availability> AVAILABILITIES_VALID = new List<Availability>
        {
            null
        };

        internal static readonly Guid USER_ID_VALID = Guid.Parse("2f3b2f1d-a8c5-4a3a-a468-7e2940a0095c");

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
            USER_ID_VALID,
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
