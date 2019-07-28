Create View [EntityCode].[ActivityQueryflow]
	AS 
SELECT	IsNull(QA.[ActivityQueryflowId], -1) As [Id],
        IsNull(QA.[ActivityQueryflowKey], '00000000-0000-0000-0000-000000000000') As [Key],
		ACT.[DeviceUuid],
		ACT.[ApplicationUuid],
		QA.[ApplicationKey],
        QA.[EntityKey],
		QA.[FlowKey],
        QA.[ActivitySqlStatement] As [SqlStatement],
		Act.[IdentityUserName],
		Act.[ExecutingContext],
		Act.[PrincipalIP4Address],		
        ACT.[ActivityContextKey],
		QA.[CreatedDate],
		QA.[ModifiedDate]
FROM	[Activity].[ActivityQueryflow] QA
Join	[Activity].[ActivityContext] ACT On Qa.ActivityContextKey = ACT.ActivityContextKey
