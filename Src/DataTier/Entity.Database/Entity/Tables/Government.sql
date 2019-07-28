CREATE TABLE [Entity].[Government] (
    [GovernmentId]			INT IDENTITY (1, 1) CONSTRAINT [DF_Government_Government] NOT NULL,
	[GovernmentKey]			UNIQUEIDENTIFIER	CONSTRAINT [DF_Government_EntityKey] DEFAULT(NewId()) NOT NULL,
    [GovernmentName]		NVARCHAR (50)    CONSTRAINT [DF_Government_GovernmentName] DEFAULT ('') NOT NULL,
    [RecordStateKey]        UNIQUEIDENTIFIER        CONSTRAINT [DF_Government_RecordState] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedActivityKey]	UNIQUEIDENTIFIER         CONSTRAINT [DF_Government_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModifiedActivityKey]	UNIQUEIDENTIFIER         CONSTRAINT [DF_Government_ModifiedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]	DATETIME         CONSTRAINT [DF_Government_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]	DATETIME         CONSTRAINT [DF_Government_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Government] PRIMARY KEY CLUSTERED ([GovernmentId] ASC),
	CONSTRAINT [FK_Government_Entity] FOREIGN KEY ([GovernmentKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_Government_RecordState] FOREIGN KEY ([RecordStateKey]) REFERENCES [Entity].[RecordState] ([RecordStateKey]),
	CONSTRAINT [FK_Government_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
	CONSTRAINT [FK_Government_ModifiedActivity] FOREIGN KEY ([ModifiedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Government_Entity] ON [Entity].[Government] ([GovernmentKey] Asc)
Go
