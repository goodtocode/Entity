﻿Create PROCEDURE [EntityCode].[ScheduleSlotSave]
    @Id                     Int,
	@Key					Uniqueidentifier,
	@ScheduleKey			Uniqueidentifier,
	@SlotKey				Uniqueidentifier,
	@ActivityContextKey		Uniqueidentifier
AS
   
	-- Validate Data
	If  (@ActivityContextKey <> '00000000-0000-0000-0000-000000000000')
	Begin
		-- Pull by unique key
		Select Top 1 @Id = IsNull([ScheduleSlotId], -1), @Key = IsNull([ScheduleSlotKey], @Key) From [Entity].[ScheduleSlot] Where [ScheduleKey] = @ScheduleKey And [SlotKey] = @SlotKey
		-- Insert Only
		If (@Id Is Null) Or (@Id = -1)
		Begin
            -- Insert Schedule
            Select @Key = IsNull(NullIf(@Key, '00000000-0000-0000-0000-000000000000'), NewId())
            Insert Into [Entity].[ScheduleSlot] (ScheduleSlotKey, ScheduleKey, SlotKey, ModifiedActivityKey, CreatedActivityKey) 
                Values (@Key, @ScheduleKey, @SlotKey, @ActivityContextKey, @ActivityContextKey)
            Select @Id = SCOPE_IDENTITY()
		End
	End
	-- Return data
	Select	IsNull(@Id, -1) As Id, IsNull(@Key, '00000000-0000-0000-0000-000000000000') As [Key]
