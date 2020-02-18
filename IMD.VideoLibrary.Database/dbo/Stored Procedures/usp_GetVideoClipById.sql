CREATE PROCEDURE  [dbo].[usp_GetVideoClipById]
(
       @VideoClipId INT
)
AS
BEGIN

SELECT Id, Name, [Description], VideoDefinition, VideoStandard, StartTime, EndTime FROM VideoClip WHERE Id = @VideoClipId;

END