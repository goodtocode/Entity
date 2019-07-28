Create View [EntityCode].[VentureEntityOption]
	AS 
Select	CP.VentureEntityOptionId As [Id], 
        CP.VentureEntityOptionKey As [Key], 
        CP.VentureKey,
		CP.EntityKey,
		P.OptionKey,
		P.OptionGroupKey, 
        P.OptionName,
        P.OptionDescription,
		CP.ModifiedActivityKey As ActivityContextKey, 
        CP.ModifiedDate,
		CP.CreatedDate
From	[Entity].VentureEntityOption CP
Join	[Entity].[Option] P	On CP.OptionKey = P.OptionKey
