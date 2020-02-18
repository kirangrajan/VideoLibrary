CREATE PROCEDURE [dbo].[usp_RemoveClipFromReel]
(
    @VideoReelId INT,
    @VideoClipId INT
)
AS
BEGIN
	DELETE FROM
		VideoReelVideoClipLink
	WHERE  VideoReelId = @VideoReelId
		AND  VideoClipId = @VideoClipId
END