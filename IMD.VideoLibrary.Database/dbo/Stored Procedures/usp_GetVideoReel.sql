CREATE PROCEDURE [dbo].[usp_GetVideoReel]
(
	@VideoReelId INT
)
AS
BEGIN

       SELECT Id, Name, [Description], VideoDefinition, VideoStandard, TotalDuration FROM VideoReel WHERE id = @VideoReelId

       SELECT Id, Name, [Description], VideoDefinition, VideoStandard, StartTime, EndTime FROM VideoClip

       SELECT Id, VideoReelId, VideoClipId FROM VideoReelVideoClipLink  WHERE VideoReelId = @VideoReelId

END
