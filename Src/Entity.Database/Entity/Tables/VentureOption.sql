CREATE TABLE [Entity].[VentureOption] (
    [VentureOptionId]        INT IDENTITY (1, 1) CONSTRAINT [DF_VentureOption_VentureOptionId] NOT NULL,
    [VentureOptionKey]		UNIQUEIDENTIFIER CONSTRAINT [DF_VentureOption_VentureOptionKey] DEFAULT(NewId()) NOT NULL,
    [VentureKey]             UNIQUEIDENTIFIER CONSTRAINT [DF_VentureOption_Entity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [OptionKey]             UNIQUEIDENTIFIER CONSTRAINT [DF_VentureOption_Option] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [CreatedActivityKey]      UNIQUEIDENTIFIER         CONSTRAINT [DF_VentureOption_CreatedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
    [ModifiedActivityKey]     UNIQUEIDENTIFIER         CONSTRAINT [DF_VentureOption_ModifiedActivity] DEFAULT('00000000-0000-0000-0000-000000000000') NOT NULL,
	[CreatedDate]  DATETIME         CONSTRAINT [DF_VentureOption_CreatedDate] DEFAULT (getutcdate()) NOT NULL,
    [ModifiedDate] DATETIME         CONSTRAINT [DF_VentureOption_ModifiedDate] DEFAULT (getutcdate()) NOT NULL,    
    CONSTRAINT [PK_VentureOption] PRIMARY KEY CLUSTERED ([VentureOptionId] ASC),
    CONSTRAINT [FK_VentureOption_Venture] FOREIGN KEY ([VentureKey]) REFERENCES [Entity].[Venture] ([VentureKey]),
    CONSTRAINT [FK_VentureOption_Option] FOREIGN KEY ([OptionKey]) REFERENCES [Entity].[Option] ([OptionKey]),
	CONSTRAINT [FK_VentureOption_CreatedActivity] FOREIGN KEY ([CreatedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey]),
	CONSTRAINT [FK_VentureOption_ModifiedActivity] FOREIGN KEY ([ModifiedActivityKey]) REFERENCES [Activity].[ActivityContext] ([ActivityContextKey])
);
GO
CREATE UNIQUE NonCLUSTERED INDEX [IX_VentureOption_All] ON [Entity].[VentureOption] ([VentureKey] Asc, [OptionKey] Asc)
GO
