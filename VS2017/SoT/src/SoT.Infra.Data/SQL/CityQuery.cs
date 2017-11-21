namespace SoT.Infra.Data.SQL
{
    public class CityQuery
    {
        public static readonly string GET_ALL = @"
            SELECT *
            FROM City c";

        public static readonly string GET_BY_ID = @"
            SELECT *
            FROM City c
            WHERE c.CityId = @ID";

        public static readonly string GET_ACTIVE_BY_COUNTRY_ID = @"
            SELECT *
            FROM City c
            WHERE c.CountryId = @COUNTRY_ID
                AND c.Active = 'true'";
    }
}
