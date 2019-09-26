Create Procedure [EntityCode].[GovernmentInfoDelete]
	@Id	                INT,
    @Key				uniqueidentifier,
	@ActivityContextKey	uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(GovernmentId, -1) From [Entity].[Government] P Where [GovernmentKey] = @Key
            If (@Id <> -1) AND (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
			Begin
	            Update	[Entity].Government
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	GovernmentId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
			
		End Catch
    End