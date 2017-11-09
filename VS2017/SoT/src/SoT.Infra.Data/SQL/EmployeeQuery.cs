namespace SoT.Infra.Data.SQL
{
    public class EmployeeQuery
    {
        public static readonly string GET_ALL = @"
            SELECT *
            FROM Employee e";

        public static readonly string GET_BY_ID = @"
            SELECT *
            FROM Employee e
            WHERE e.EMPLOYEE_ID = @EMPLOYEE_ID";
    }
}
