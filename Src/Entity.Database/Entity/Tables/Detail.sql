CREATE TABLE [Entity].[Detail] (
    [DetailId]             INT IDENTITY (1, 1) CONSTRAINT [DF_Detail_Id] NOT NULL,
    [DetailKey]            UNIQUEIDENTIFIER CONSTRAINT [DF_Detail_Key] DEFAULT (NewID()) NOT NULL,
    [DetailTypeKey]        UNIQUEIDENTIFIER CONSTRAINT [DF_Detail_DetailType] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [DetailData]            NVARCHAR (2000)  CONSTRAINT [DF_Detail_DetailData] DEFAULT ('') NOT NULL,
    [CreatedActivityKey]        UNIQUEIDENTIFIER         CONSTRAINT [DF_Detail_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModifiedActivityKey]       UNIQUEIDENTIFIER         CONSTRAINT [DF_Detail_ModifiedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]               DATETIME         CONSTRAINT [DF_Detail_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]              DATETIME         CONSTRAINT [DF_Detail_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Detail] PRIMARY KEY CLUSTERED ([DetailId] ASC),
    CONSTRAINT [FK_Detail_DetailType] FOREIGN KEY ([DetailTypeKey]) REFERENCES [Entity].[DetailType] ([DetailTypeKey]),
	CONSTRAINT [FK_Detail_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
	CONSTRAINT [FK_Detail_ModifiedActivity] FOREIGN KEY ([ModifiedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Detail_Key] ON [Entity].[Detail] ([DetailKey] Asc)
GO
