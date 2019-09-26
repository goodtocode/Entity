CREATE Procedure [EntityCode].[ActivityQueryflowInsert]		
    @Key				Uniqueidentifier,
	@FlowKey			Uniqueidentifier,	
    @ApplicationKey		Uniqueidentifier,
    @EntityKey			Uniqueidentifier,
    @SqlStatement           nvarchar(4000),
    @ActivityContextKey	    Uniqueidentifier
AS
	-- Local variables
    Declare @Id As Int = -1

	SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
	-- Attempt to write values, else log exception
	Begin Try
        Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
    	Insert Into [Activity].[ActivityQueryflow] ([ActivityQueryflowKey], [ActivityContextKey], [FlowKey], [ApplicationKey], [EntityKey], [ActivitySqlStatement])
			Values (@Key, @ActivityContextKey, @FlowKey, @ApplicationKey, @EntityKey, @SqlStatement)
		Select @Id = SCOPE_IDENTITY()
	End Try
	Begin Catch
		Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
	End Catch
	
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
