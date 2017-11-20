namespace SoT.Infra.Data.SQL
{
    public class CategoryQuery
    {
        public static readonly string GET_ALL = @"
            SELECT *
            FROM Category c";

        public static readonly string GET_BY_ID = @"
            SELECT *
            FROM Category c
            WHERE c.CategoryId = @ID";
    }
}
