CREATE TABLE [Activity].[ActivityWorkflow] (
    [ActivityWorkflowId]			INT IDENTITY (1, 1) CONSTRAINT [DF_ActivityWorkflow_ActivityWorkflowId] NOT NULL,
    [ActivityWorkflowKey]	        UniqueIdentifier	CONSTRAINT [DF_ActivityWorkflow_ActivityWorkflowKey] DEFAULT (NewID()) NOT NULL,	
    [ApplicationKey]		        UniqueIdentifier CONSTRAINT [DF_ActivityWorkflow_Application] DEFAULT(NULL),
    [EntityKey]				        UniqueIdentifier CONSTRAINT [DF_ActivityWorkflow_EntityId] DEFAULT(NULL),
    [FlowKey]						UniqueIdentifier CONSTRAINT [DF_WorkflowActivitry_FlowId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [FlowStepKey]					UniqueIdentifier CONSTRAINT [DF_ActivityWorkflow_FlowStepId] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,	
    [ActivityContextKey]			UniqueIdentifier CONSTRAINT [DF_ActivityWorkflow_ActivityContext] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedDate]					DATETIME         CONSTRAINT [DF_ActivityWorkflow_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate]					DATETIME         CONSTRAINT [DF_ActivityWorkflow_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_ActivityWorkflow] PRIMARY KEY CLUSTERED ([ActivityWorkflowId] ASC),
	CONSTRAINT [FK_ActivityWorkflow_ActivityContext] FOREIGN KEY ([ActivityContextKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
    CONSTRAINT [FK_ActivityWorkflow_Application] FOREIGN KEY ([ApplicationKey]) REFERENCES [Entity].[Application] ([ApplicationKey]),
    CONSTRAINT [FK_ActivityWorkflow_Entity] FOREIGN KEY ([EntityKey]) REFERENCES [Entity].[Entity] ([EntityKey]),
    CONSTRAINT [FK_ActivityWorkflow_Workflow] FOREIGN KEY ([FlowKey]) REFERENCES [Entity].[Flow] ([FlowKey]),
    CONSTRAINT [FK_ActivityWorkflow_FlowStep] FOREIGN KEY ([FlowStepKey]) REFERENCES [Entity].[FlowStep] ([FlowStepKey]),
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_ActivityWorkflow_Key] ON [Activity].[ActivityWorkflow] ([ActivityWorkflowKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ActivityWorkflow_ActivityContext] ON [Activity].[ActivityWorkflow] ([ActivityContextKey] Asc)
GO
CREATE NonCLUSTERED INDEX [IX_ActivityWorkflow_All] ON [Activity].[ActivityWorkflow] ([EntityKey] Asc)
GO
