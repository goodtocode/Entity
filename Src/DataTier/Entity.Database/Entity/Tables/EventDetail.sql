CREATE TABLE [Entity].[EventDetail] (
    [EventDetailId]             INT IDENTITY (1, 1) CONSTRAINT [DF_EventDetail_Id] NOT NULL,
    [EventDetailKey]            UNIQUEIDENTIFIER CONSTRAINT [DF_EventDetail_Key] DEFAULT (NewID()) NOT NULL,
    [EventKey]                  UNIQUEIDENTIFIER CONSTRAINT [DF_EventDetail_Event] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DetailKey]                 UNIQUEIDENTIFIER CONSTRAINT [DF_EventDetail_Detail] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedActivityKey]        UNIQUEIDENTIFIER         CONSTRAINT [DF_EventDetail_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModifiedActivityKey]       UNIQUEIDENTIFIER         CONSTRAINT [DF_EventDetail_ModifiedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_EventDetail_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_EventDetail_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_EventDetail] PRIMARY KEY CLUSTERED ([EventDetailId] ASC),
    CONSTRAINT [FK_EventDetail_Event] FOREIGN KEY ([EventKey]) REFERENCES [Entity].[Event] ([EventKey]),
    CONSTRAINT [FK_EventDetail_Detail] FOREIGN KEY ([DetailKey]) REFERENCES [Entity].[Detail] ([DetailKey]),
    CONSTRAINT [UQ_EventDetail_EventDetailId] UNIQUE NONCLUSTERED ([EventKey] ASC, [EventDetailKey] ASC),
	CONSTRAINT [FK_EventDetail_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
	CONSTRAINT [FK_EventDetail_ModifiedActivity] FOREIGN KEY ([ModifiedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventDetail_Key] ON [Entity].[EventDetail] ([EventDetailKey] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_EventDetail_All] ON [Entity].[EventDetail] ([EventKey] Asc, [EventDetailKey] Asc)
