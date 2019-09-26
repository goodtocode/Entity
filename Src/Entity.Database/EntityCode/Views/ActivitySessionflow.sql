Create View [EntityCode].[ActivitySessionflow]
	AS 
SELECT	IsNull(Sa.[ActivitySessionflowId], -1) As [Id],
		IsNull(Sa.[ActivitySessionflowKey], '00000000-0000-0000-0000-000000000000') As [Key],
		ACT.[DeviceUuid],
		ACT.[ApplicationUuid],
        SA.[EntityKey],
		Sa.[FlowKey],
		SA.[ApplicationKey],
		ACT.[IdentityUserName],
		SA.[SessionflowData],
        ACT.[ActivityContextKey],
		Sa.[CreatedDate],
		Sa.[ModifiedDate]
FROM	[Activity].[ActivitySessionflow] Sa
Join	[Activity].[ActivityContext] ACT On Sa.ActivityContextKey = ACT.ActivityContextKey
