CREATE TABLE [dbo].[VideoReelVideoClipLink] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [VideoReelId] INT NOT NULL,
    [VideoClipId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([VideoClipId]) REFERENCES [dbo].[VideoClip] ([Id]),
    FOREIGN KEY ([VideoReelId]) REFERENCES [dbo].[VideoReel] ([Id])
);

