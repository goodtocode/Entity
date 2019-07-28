CREATE TABLE [Activity].[ActivityQueryflow] (
    [ActivityQueryflowId]			INT IDENTITY (1, 1) CONSTRAINT [DF_ActivityQueryflow_ActivityQueryflowId] NOT NULL,
    [ActivityQueryflowKey]	        UniqueIdentifier	CONSTRAINT [DF_ActivityQueryflow_ActivityQuerylowKey] DEFAULT (NewID()) NOT NULL,	
    [ApplicationKey]		        UniqueIdentifier CONSTRAINT [DF_ActivityQueryflow_Application] DEFAULT(NULL),
    [EntityKey]				        UniqueIdentifier CONSTRAINT [DF_ActivityQueryflow_EntityId] DEFAULT(NULL),
    [FlowKey]						UniqueIdentifier CONSTRAINT [DF_ActivityQueryflow_FlowId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,	
    [ActivitySqlStatement]	        NVARCHAR (2000)  CONSTRAINT [DF_ActivityQueryflow_ActivitySqlStatement] DEFAULT ('') NOT NULL,
    [ActivityContextKey]			UniqueIdentifier CONSTRAINT [DF_ActivityQueryflow_ActivityContext] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]					DATETIME         CONSTRAINT [DF_ActivityQueryflow_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]					DATETIME         CONSTRAINT [DF_ActivityQueryflow_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ActivityQueryflow] PRIMARY KEY CLUSTERED ([ActivityQueryflowId] ASC),
	CONSTRAINT [FK_ActivityQueryflow_Activity] FOREIGN KEY ([ActivityContextKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
    CONSTRAINT [FK_ActivityQueryflow_Application] FOREIGN KEY ([ApplicationKey]) REFERENCES [Entity].[Application] ([ApplicationKey]),
    CONSTRAINT [FK_ActivityQueryflow_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_ActivityQueryflow_Queryflow] FOREIGN KEY ([FlowKey]) REFERENCES [Entity].[Flow] ([FlowKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ActivityQueryflow_Key] ON [Activity].[ActivityQueryflow] ([ActivityQueryflowKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ActivityQueryflow_Activity] ON [Activity].[ActivityQueryflow] ([ActivityContextKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ActivityQueryflow_All] ON [Activity].[ActivityQueryflow] ([EntityKey] Asc)
GO
