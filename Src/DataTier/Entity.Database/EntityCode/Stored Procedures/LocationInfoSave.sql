Create PROCEDURE [EntityCode].[LocationInfoSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@Name					nvarchar(50),
	@Description			nvarchar(200),
	@ActivityContextKey		Uniqueidentifier
AS
	-- Local variables
	-- Initialize
	Select 	@Name			= RTRIM(LTRIM(@Name))
	Select 	@Description	= RTRIM(LTRIM(@Description))

	-- Only execute if data is good
	If  (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([LocationKey], @Key) From [Entity].[Location] Where [LocationId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([LocationId], -1) From [Entity].[Location] Where [LocationKey] = @Key
		-- Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
			-- Insert
			Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
			Insert Into [Entity].[Location] (LocationKey, LocationName, LocationDescription, RecordStateKey, CreatedActivityKey, ModifiedActivityKey)
				Values (@Key, @Name, @Description, '00000000-0000-0000-0000-000000000000', @ActivityContextKey, @ActivityContextKey)
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
			-- Location master
			Update [Entity].[Location]
			Set	LocationName			= @Name,
				LocationDescription	    = @Description,
				ModifiedActivityKey	= @ActivityContextKey,
				ModifiedDate		= GetUTCDate()
			Where	LocationId	= @Id
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
