CREATE TABLE [dbo].[VideoClip] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100)  NULL,
    [Description]     NVARCHAR (1000) NULL,
    [VideoDefinition] INT             NULL,
    [VideoStandard]   INT             NULL,
    [StartTime]       NVARCHAR (1000) NULL,
    [EndTime]         NVARCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

