CREATE TABLE [Entity].[Area] (
    [AreaId]			    INT	IDENTITY (1, 1) CONSTRAINT [DF_Area_Id] NOT NULL,
    [AreaKey]			    UNIQUEIDENTIFIER	CONSTRAINT [DF_Area_Key] NOT NULL DEFAULT(NewId()),
	[Area]				    Geometry			NOT NULL,
    [CreatedActivityKey]	UNIQUEIDENTIFIER    CONSTRAINT [DF_Area_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]		    DATETIME			CONSTRAINT [DF_Area_CreatedDate] DEFAULT (getutcdate()) NOT NULL,	
    CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED ([AreaId] ASC),
	CONSTRAINT [FK_Area_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_Area_Key] ON [Entity].[Area] ([AreaKey] Asc)
GO
