Create Procedure [EntityCode].[ScheduleSlotDelete]
	@Id	                INT,
    @Key				uniqueidentifier,
	@ActivityContextKey	Uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(ScheduleSlotId, -1) From [Entity].[ScheduleSlot] P Where [ScheduleSlotKey] = @Key
            If (@Id <> -1) AND (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
			Begin
	            Delete From	[Entity].[ScheduleSlot]
	            Where	ScheduleSlotId = @Id
			End
			
		End Try
		Begin Catch
			Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
		End Catch
    End