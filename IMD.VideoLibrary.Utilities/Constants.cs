namespace IMD.VideoLibrary.Utilities
{
    /// <summary>
    /// Common constants
    /// </summary>
    public class Constants
    {
        public const string DefaultSQLConnectionString = "IMDSQLConnection";

        /// SQL Parameters
        public const string Parameter_VideoReelId = "@VideoReelId";
        public const string Parameter_VideoClipId = "@VideoClipId";
        public const string Parameter_VideoReelName = "@VideoReelName";
        /// SQL Field Names
        public const string Field_VideoDefinition = "VideoDefinition";
        public const string Field_VideoStandard = "VideoStandard";
        public const string Field_Id = "Id";
        public const string Field_Name = "Name";
        public const string Field_Description = "Description";
        public const string Field_StartTime = "StartTime";
        public const string Field_EndTime = "EndTime";
        public const string Field_VideoReelId = "VideoReelId";
        public const string Field_VideoClipId = "VideoClipId";
        public const string Field_TotalDuration = "TotalDuration";

        /// SQL Procedures
        public const string Procedure_GetAllVideoReels = "usp_GetAllVideoReels";
        public const string Procedure_GetVideoReel = "usp_GetVideoReel";
        public const string Procedure_RemoveClipFromReel = "usp_RemoveClipFromReel";
        public const string Procedure_AddClipToReel = "usp_AddClipToReel";
        public const string Procedure_GetVideoClipById = "usp_GetVideoClipById";
        public const string Procedure_GetAllVideoClips = "usp_GetAllVideoClips";

        public const string Procedure_SaveVideoReel = "sp_SaveVideoReelName";
    }
}
