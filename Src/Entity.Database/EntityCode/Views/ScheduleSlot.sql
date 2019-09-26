Create VIEW [EntityCode].[ScheduleSlot]
AS 
	Select	S.ScheduleSlotId As [Id], 
			S.ScheduleSlotKey As [Key],
			S.ScheduleKey,
			S.SlotKey,
            S.CreatedActivityKey As [ActivityContextKey],
			S.CreatedDate, 
			S.ModifiedDate
	From	[Entity].[ScheduleSlot] S