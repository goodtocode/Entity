Create Procedure [EntityCode].[ActivitySessionflowUpdate]
	@Id					INT,
    @Key				Uniqueidentifier,
	@ApplicationKey		Uniqueidentifier,
    @EntityKey			Uniqueidentifier,
	@SessionflowData	nvarchar(4000),
    @ActivityContextKey	Uniqueidentifier
AS	
	Begin Try
        
		-- Both Id and Key are valid
		If (@Id <> -1) Select Top 1 @Key = IsNull([ActivitySessionflowKey], @Key) From [Activity].[ActivitySessionflow] Where [ActivitySessionflowId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([ActivitySessionflowId], -1) From [Activity].[ActivitySessionflow] Where [ActivitySessionflowKey] = @Key
		-- Update
		Update	[Activity].[ActivitySessionflow]
		Set		[ApplicationKey]	        = IsNull(NullIf(@ApplicationKey, '00000000-0000-0000-0000-000000000000'), [ApplicationKey]),
                [EntityKey]                 = IsNull(NullIf(@EntityKey, '00000000-0000-0000-0000-000000000000'), [EntityKey]),
                [SessionflowData]	        = IsNull(NullIf(@SessionflowData, ''), [SessionflowData]),
				[ModifiedDate]				= GETUTCDATE()
		Where	[ActivitySessionflowId]		= @Id
        
	End Try
	Begin Catch
        
		Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
        
	End Catch

    Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]