CREATE TABLE [Entity].[ScheduleSlot] (
    [ScheduleSlotId]    INT IDENTITY (1, 1) CONSTRAINT [DF_ScheduleSlot_ScheduleSlotId] NOT NULL,
    [ScheduleSlotKey]   UNIQUEIDENTIFIER CONSTRAINT [DF_ScheduleSlot_ScheduleSlotKey] DEFAULT(NewId()) NOT NULL,
    [ScheduleKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_ScheduleSlot_ScheduleKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[SlotKey]			UNIQUEIDENTIFIER CONSTRAINT [DF_ScheduleSlot_SlotKey] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,	
    [CreatedActivityKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_ScheduleSlot_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModifiedActivityKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_ScheduleSlot_ModifiedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]			DATETIME         CONSTRAINT [DF_ScheduleSlot_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]			DATETIME         CONSTRAINT [DF_ScheduleSlot_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ScheduleSlot] PRIMARY KEY CLUSTERED ([ScheduleSlotId] ASC),
	CONSTRAINT [FK_ScheduleSlot_Slot] FOREIGN KEY ([SlotKey]) REFERENCES [Entity].[Slot] ([SlotKey]),
	CONSTRAINT [FK_ScheduleSlot_Schedule] FOREIGN KEY ([ScheduleKey]) REFERENCES [Entity].[Schedule] ([ScheduleKey]),
	CONSTRAINT [FK_ScheduleSlot_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
	CONSTRAINT [FK_ScheduleSlot_ModifiedActivity] FOREIGN KEY ([ModifiedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ScheduleSlot_Key] ON [Entity].[ScheduleSlot] ([ScheduleSlotKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ScheduleSlot_Schedule] ON [Entity].[ScheduleSlot] ([ScheduleKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ScheduleSlot_Slot] ON [Entity].[ScheduleSlot] ([SlotKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ScheduleSlot_All] ON [Entity].[ScheduleSlot] ([SlotKey] Asc, [ScheduleKey] Asc)
GO