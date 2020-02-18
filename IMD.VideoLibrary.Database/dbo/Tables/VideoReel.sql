CREATE TABLE [dbo].[VideoReel] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100)  NULL,
    [Description]     NVARCHAR (1000) NULL,
    [VideoDefinition] INT             NULL,
    [VideoStandard]   INT             NULL,
    [TotalDuration]   NVARCHAR(200)          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

