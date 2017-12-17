namespace SoT.Infra.Data.SQL
{
    public static class GenderQuery
    {
        public static readonly string GET_ALL_BY_SITUATION = @"
            SELECT *
            FROM Gender g
            WHERE g.ACTIVE = @SITUATION";
    }
}
