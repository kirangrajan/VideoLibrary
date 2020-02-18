CREATE PROCEDURE  [dbo].[usp_GetAllVideoClips]
AS
BEGIN

SELECT Id, Name, [Description], VideoDefinition, VideoStandard, StartTime, EndTime FROM VideoClip
END