Create Procedure [EntityCode].[ItemInfoDelete]
	@Id	                INT,
    @Key				uniqueidentifier,
	@ActivityContextKey	Uniqueidentifier
AS
    Begin
    	
		Begin Try			
			If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull(ItemId, -1) From [Entity].[Item] P Where [ItemKey] = @Key
            If (@Id <> -1) AND (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
			Begin
	            Update	[Entity].[Item]
                Set     RecordStateKey = '081C6A5B-0817-4161-A3AD-AD7924BEA874'
	            Where	ItemId = @Id
			End
			
		End Try
		Begin Catch
			
			Exec [Activity].[ExceptionLogInsertByActivity] @ActivityContextKey;
			
		End Catch
    End