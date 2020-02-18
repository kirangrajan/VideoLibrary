CREATE PROCEDURE  [dbo].[usp_GetAllVideoReels]
AS
BEGIN

       SELECT Id, Name, [Description], VideoDefinition, VideoStandard, TotalDuration FROM VideoReel

       SELECT Id, Name, [Description], VideoDefinition, VideoStandard, StartTime, EndTime FROM VideoClip

       SELECT Id, VideoReelId, VideoClipId FROM VideoReelVideoClipLink

END