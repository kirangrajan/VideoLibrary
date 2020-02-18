CREATE PROCEDURE [dbo].[usp_SaveVideoReelName]
(
	@VideoReelName NVARCHAR(100),
	@VideoReelId INT
)
AS
BEGIN

	UPDATE VideoReel 
	SET 
		Name = ISNULL(@VideoReelName,'')
	WHERE
		Id = @VideoReelId
END
