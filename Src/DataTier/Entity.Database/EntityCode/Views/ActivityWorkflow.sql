Create View [EntityCode].[ActivityWorkflow]
	AS 
SELECT	WA.[ActivityWorkflowId] As [Id],
        WA.[ActivityWorkflowKey] As [Key],
        Wa.[ActivityContextKey],
		ACT.[DeviceUuid],
		ACT.[ApplicationUuid],
		WA.[EntityKey],
		WA.[ApplicationKey],
        Wa.[FlowKey],
		Wa.[FlowStepKey],        
		Act.[IdentityUserName],
		Act.[ExecutingContext],
		Act.[PrincipalIP4Address],
		WA.[CreatedDate],
		WA.[ModifiedDate]
FROM	[Activity].[ActivityWorkflow] WA
Join	[Activity].[ActivityContext] Act On Wa.ActivityContextKey = Act.ActivityContextKey
