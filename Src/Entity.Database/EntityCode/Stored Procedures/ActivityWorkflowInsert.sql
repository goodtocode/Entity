CREATE Procedure [EntityCode].[ActivityWorkflowInsert]
    @Key				Uniqueidentifier,
	@FlowKey			Uniqueidentifier,	
    @ApplicationKey		Uniqueidentifier,
    @EntityKey			Uniqueidentifier,
	@FlowStepKey			Uniqueidentifier,
    @ActivityContextKey	    Uniqueidentifier
AS	
    Declare @Id As INT = -1

	-- Keep record contention and dirty data to a minimum
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE	
	-- Attempt to write values, else log exception
	Begin Try
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
		Insert Into [Activity].[ActivityWorkflow] ([ActivityWorkflowKey], [ActivityContextKey], [FlowKey], [FlowStepKey],  [ApplicationKey], [EntityKey])
			Values (@Key, @ActivityContextKey, @FlowKey, @FlowStepKey,  @ApplicationKey, @EntityKey)
		Select @Id = SCOPE_IDENTITY()
	End Try
	Begin Catch
		Exec [Activity].[ExceptionLogInsertByActivity] @Key;
	End Catch
	
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
