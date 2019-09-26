CREATE Procedure [EntityCode].[ActivitySessionflowInsert]
    @Key				Uniqueidentifier,
	@FlowKey			Uniqueidentifier,	
    @ApplicationKey		Uniqueidentifier,
    @EntityKey			Uniqueidentifier,
	@SessionflowData	nvarchar(4000),
    @ActivityContextKey	Uniqueidentifier
AS
	-- Locals
	Declare @Id As INT = -1

	-- Keep record contention and dirty data to a minimum
	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	-- Attempt to write values, else log exception    
	Begin Try
        
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
        Select @EntityKey = NullIf(@EntityKey, '00000000-0000-0000-0000-000000000000')        
		Insert Into [Activity].[ActivitySessionflow] ([ActivitySessionflowKey], [ActivityContextKey], [FlowKey], [ApplicationKey], [EntityKey], [SessionflowData])
			Values (@Key, @ActivityContextKey, @FlowKey, @ApplicationKey, @EntityKey, @SessionflowData)
		Select @Id = SCOPE_IDENTITY()
        
	End Try
	Begin Catch
        
		Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
        
	End Catch

	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
