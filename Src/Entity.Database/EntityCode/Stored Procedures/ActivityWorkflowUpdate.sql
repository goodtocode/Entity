Create Procedure [EntityCode].[ActivityWorkflowUpdate]
	@Id					INT,
    @Key				Uniqueidentifier,
	@ApplicationKey		Uniqueidentifier,
    @EntityKey			Uniqueidentifier,
	@FlowStepKey		Uniqueidentifier,
    @ActivityContextKey Uniqueidentifier
AS
	Begin Try
        
	    -- Id and Key are both valid. Sync now.
	    If (@Id <> -1) Select Top 1 @Key = IsNull([ActivityWorkflowKey], @Key) From [Activity].[ActivityWorkflow] Where [ActivityWorkflowId] = @Id
	    If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([ActivityWorkflowId], -1) From [Activity].[ActivityWorkflow] Where [ActivityWorkflowKey] = @Key
        -- Update
		Update  [Activity].[ActivityWorkflow]
		Set		[ApplicationKey]	        = IsNull(NullIf(@ApplicationKey, '00000000-0000-0000-0000-000000000000'), [ApplicationKey]),
                [EntityKey]                 = IsNull(NullIf(@EntityKey, '00000000-0000-0000-0000-000000000000'), [EntityKey]),
                [FlowStepKey]		    = @FlowStepKey,
				[ModifiedDate]		    = GETUTCDATE()
		Where [ActivityWorkflowKey]	= @Key
        
	End Try
	Begin Catch
        
		Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
        
	End Catch

    Select	IsNull(@Id, -1) As [Id], IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]