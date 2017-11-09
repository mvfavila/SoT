﻿namespace SoT.Infra.Data.SQL
{
    public class ProviderQuery
    {
        public static readonly string GET_ALL = @"
            SELECT *
            FROM Provider p";

        public static readonly string GET_BY_ID = @"
            SELECT *
            FROM Provider p
            WHERE p.ID = @ID";

        public static readonly string GET_WITH_EMPLOYEE_BY_ID = @"
            SELECT *
            FROM Provider p
            INNER JOIN Employee e ON p.Id = e.EmployeeId
            WHERE p.ID = @ID";
    }
}