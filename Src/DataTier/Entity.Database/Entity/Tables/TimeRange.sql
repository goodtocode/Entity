﻿CREATE TABLE [Entity].[TimeRange] (
    [TimeRangeId]           INT IDENTITY (1, 1) CONSTRAINT [DF_TimeRange_TimeRangeId] NOT NULL,
    [TimeRangeKey]          UNIQUEIDENTIFIER CONSTRAINT [DF_Event_TimeRangeKey] DEFAULT (NewId()) NOT NULL,
	[BeginDate]	            DATETIME         CONSTRAINT [DF_TimeRange_BeginDate] DEFAULT (getutcdate()) NOT NULL,
	[EndDate]	            DATETIME         CONSTRAINT [DF_TimeRange_EndDate] DEFAULT (getutcdate()) NOT NULL,
    [CreatedActivityKey]	UNIQUEIDENTIFIER         CONSTRAINT [DF_TimeRange_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]           DATETIME         CONSTRAINT [DF_TimeRange_CreatedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_TimeRange] PRIMARY KEY CLUSTERED ([TimeRangeId] ASC),
	CONSTRAINT [FK_TimeRange_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_TimeRange_All] ON [Entity].[TimeRange] ([BeginDate] Asc, [EndDate] Asc)
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_TimeRange_TimeRangeKey] ON [Entity].[TimeRange] ([TimeRangeKey] Asc)
GO