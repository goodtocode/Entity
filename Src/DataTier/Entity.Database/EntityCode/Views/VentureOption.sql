Create View [EntityCode].[VentureOption]
	AS 
Select	CP.VentureOptionId As [Id], 
        CP.VentureOptionKey As [Key], 
		CP.VentureKey,
		P.OptionKey,
		P.OptionGroupKey, 
        P.OptionName,
        P.OptionDescription,
		CP.ModifiedActivityKey As ActivityContextKey, 
        CP.ModifiedDate,
		CP.CreatedDate
From	[Entity].VentureOption CP
Join	[Entity].[Option] P	On CP.OptionKey = P.OptionKey
