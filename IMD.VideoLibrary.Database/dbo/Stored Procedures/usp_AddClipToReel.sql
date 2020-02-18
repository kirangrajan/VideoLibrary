CREATE PROCEDURE  [dbo].[usp_AddClipToReel]
(
       @VideoReelId INT,
       @VideoClipId INT
)
AS
BEGIN

       INSERT INTO 
       VideoReelVideoClipLink( VideoReelId, VideoClipId )
       VALUES (@VideoReelId, @VideoClipId)
END