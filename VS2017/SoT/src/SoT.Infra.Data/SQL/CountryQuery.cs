namespace SoT.Infra.Data.SQL
{
    public class CountryQuery
    {
        public static readonly string GET_ALL = @"
            SELECT *
            FROM Country c";

        public static readonly string GET_ALL_BY_SITUATION = @"
            SELECT *
            FROM Country c
            WHERE c.ACTIVE = @SITUATION";

        public static readonly string GET_BY_ID = @"
            SELECT *
            FROM Country c
            WHERE c.CountryId = @ID";
    }
}
