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
            WHERE c.CITY_ID = @ID";
    }
}
