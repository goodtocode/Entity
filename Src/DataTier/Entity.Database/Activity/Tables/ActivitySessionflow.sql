CREATE TABLE [Activity].[ActivitySessionflow] (
    [ActivitySessionflowId]		INT IDENTITY (1, 1) CONSTRAINT [DF_ActivitySessionflow_ActivitySessionflowId] NOT NULL, 
    [ActivitySessionflowKey]	UniqueIdentifier	CONSTRAINT [DF_ActivitySessionflow_ActivitySessionflowKey] DEFAULT (NewID()) NOT NULL,	
    [ApplicationKey]		    UniqueIdentifier CONSTRAINT [DF_ActivitySessionflow_Application] DEFAULT(NULL),
    [EntityKey]				    UniqueIdentifier CONSTRAINT [DF_ActivitySessionflow_EntityId] DEFAULT(NULL),
	[FlowKey]					UniqueIdentifier CONSTRAINT [DF_ActivitySessionflow_Flow] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[SessionflowData]	        NVARCHAR (4000)   CONSTRAINT [DF_ActivitySessionflow_SessionflowData] DEFAULT ('') NOT NULL,
    [ActivityContextKey]		UniqueIdentifier CONSTRAINT [DF_ActivitySessionflow_ActivityContext] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]				DATETIME         CONSTRAINT [DF_ActivitySessionflow_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]				DATETIME         CONSTRAINT [DF_ActivitySessionflow_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ActivitySessionflow] PRIMARY KEY CLUSTERED ([ActivitySessionflowId] ASC),
	CONSTRAINT [FK_ActivitySessionflow_Activity] FOREIGN KEY ([ActivityContextKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
    CONSTRAINT [FK_ActivitySessionflow_Application] FOREIGN KEY ([ApplicationKey]) REFERENCES [Entity].[Application] ([ApplicationKey]),
    CONSTRAINT [FK_ActivitySessionflow_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
	CONSTRAINT [FK_ActivitySessionflow_Flow] FOREIGN KEY ([FlowKey]) REFERENCES [Entity].[Flow] ([FlowKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ActivitySessionflow_Key] ON [Activity].[ActivitySessionflow] ([ActivitySessionflowKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ActivitySessionflow_Activity] ON [Activity].[ActivitySessionflow] ([ActivityContextKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ActivitySessionflow_All] ON [Activity].[ActivitySessionflow] ([EntityKey] Asc)
GO
