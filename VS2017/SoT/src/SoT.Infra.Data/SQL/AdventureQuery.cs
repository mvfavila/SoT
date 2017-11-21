﻿namespace SoT.Infra.Data.SQL
{
	public class AdventureQuery
	{
		public static readonly string GET_WITH_ADDRESS_BY_ID = @"
			SELECT
				adventure.*,
				address.AddressId as 'Id',
				address.*
			FROM Adventure adventure
			INNER JOIN Address address ON adventure.AddressId = address.AddressId
			WHERE adventure.AdventureId = @ID
				adventure.UserId = @USER_ID";
	}
}