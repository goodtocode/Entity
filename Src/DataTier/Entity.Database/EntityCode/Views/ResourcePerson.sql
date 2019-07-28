Create View [EntityCode].[ResourcePerson]
As
Select	RP.ResourcePersonId As [Id],
		RP.ResourcePersonKey As [Key],
        R.ResourceKey,
        R.ResourceName, 
		R.ResourceDescription, 
        P.PersonKey,
		P.FirstName, 
		P.MiddleName, 
		P.LastName, 
		P.BirthDate,
		P.GenderCode, 
		RP.ModifiedActivityKey As ActivityContextKey,
		RP.CreatedDate, 
		RP.ModifiedDate
From	[Entity].[ResourcePerson] RP
    Join [Entity].[Resource] R On RP.ResourceKey = R.ResourceKey
    Join [Entity].[Person] P On RP.PersonKey = P.PersonKey
Where   RP.RecordStateKey <> '081C6A5B-0817-4161-A3AD-AD7924BEA874'