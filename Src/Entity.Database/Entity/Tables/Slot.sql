CREATE TABLE [Entity].[Slot] (
    [SlotId]            INT IDENTITY (1, 1) CONSTRAINT [DF_Slot_SlotId] NOT NULL,
	[SlotKey]           UNIQUEIDENTIFIER CONSTRAINT [DF_Slot_SlotKey] DEFAULT(NewId()) NOT NULL,
    [SlotName]			NVARCHAR (50)    CONSTRAINT [DF_Slot_SlotName] DEFAULT ('') NOT NULL,
    [SlotDescription]	NVARCHAR (2000)   CONSTRAINT [DF_Slot_SlotDescription] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Slot_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedActivityKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_Slot_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModifiedActivityKey]	UNIQUEIDENTIFIER CONSTRAINT [DF_Slot_ModifiedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]       DATETIME         CONSTRAINT [DF_Slot_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]      DATETIME         CONSTRAINT [DF_Slot_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Slot] PRIMARY KEY CLUSTERED ([SlotId] ASC),
    CONSTRAINT [FK_Slot_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey]),
    CONSTRAINT [FK_Slot_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
	CONSTRAINT [FK_Slot_ModifiedActivity] FOREIGN KEY ([ModifiedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Slot_SlotKey] ON [Entity].[Slot] ([SlotKey] Asc)
GO