namespace SoT.Infra.Data.SQL
{
	public static class AdventureQuery
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

		public static readonly string GET_ALL_WITH_ADDRESS_BY_USER_ID = @"
			SELECT
				adventure.*,
				address.AddressId as 'Id',
				address.*
			FROM Adventure adventure
			INNER JOIN Address address ON adventure.AddressId = address.AddressId
			WHERE adventure.ProviderId = (SELECT TOP 1 ProviderId FROM Adventure WHERE UserId = @USER_ID)";
	}
}
