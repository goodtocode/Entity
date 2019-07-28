﻿Create PROCEDURE [EntityCode].[VentureEntityOptionSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
    @VentureKey			    Uniqueidentifier,
    @EntityKey			    Uniqueidentifier,
    @OptionKey			    Uniqueidentifier,
	@ActivityContextKey		Uniqueidentifier
AS
	-- Only execute if data is good
	If  (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Id and Key are both valid. Sync now.
		If (@Id <> -1) Select Top 1 @Key = IsNull([VentureEntityOptionKey], @Key) From [Entity].[VentureEntityOption] Where [VentureEntityOptionId] = @Id
		If (@Id = -1 AND @Key <> '00000000-0000-0000-0000-000000000000') Select Top 1 @Id = IsNull([VentureEntityOptionId], -1) From [Entity].[VentureEntityOption] Where [VentureEntityOptionKey] = @Key
		-- Insert vs. Update
		If (@Id Is Null) Or (@Id = -1)
		Begin
			-- Insert
			Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
			Insert Into [Entity].[VentureEntityOption] (VentureEntityOptionKey, VentureKey, EntityKey, OptionKey, CreatedActivityKey, ModifiedActivityKey)
				Values (@Key, @VentureKey, @EntityKey, @OptionKey, @ActivityContextKey, @ActivityContextKey)
			Select @Id = SCOPE_IDENTITY()
		End
		Else
		Begin
			-- VentureEntityOption master
			Update [Entity].[VentureEntityOption]
			Set	    OptionKey           = @OptionKey,
				    ModifiedActivityKey	= @ActivityContextKey,
				    ModifiedDate		= GetUTCDate()
			Where	VentureEntityOptionId	= @Id
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
