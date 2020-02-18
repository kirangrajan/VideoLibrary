using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.Repository.Common;
using IMD.VideoLibrary.Repository.Interfaces;
using IMD.VideoLibrary.Utilities;
using System.Collections.Generic;
using System.Data;

namespace IMD.VideoLibrary.Repository
{
    public class VideoClipRepository : IVideoClipRepository
    {
        /// <summary>
        /// Get All Clips
        /// </summary>
        /// <param name="clipId">Clip Id</param>
        /// <returns>Video Clip details</returns>
        public VideoClip GetClipDetails(int clipId)
        {
            IList<VideoClip> videoClips;

            var database = ApplicationDatabase.Create();

            using (var command = database.GetStoredProcCommand(Constants.Procedure_GetVideoClipById))
            {
                database.AddInParameter(command, Constants.Parameter_VideoClipId, DbType.Int32, clipId);

                videoClips = this.Populate(database.ExecuteDataSet(command));
            }

            return videoClips[0];
        }

        /// <summary>
        /// Get All Clips
        /// </summary>
        /// <returns>list of video clips</returns>
        public IList<VideoClip> GetAllClips()
        {
            IList<VideoClip> videoClips;

            var database = ApplicationDatabase.Create();

            using (var command = database.GetStoredProcCommand(Constants.Procedure_GetAllVideoClips))
            {
                videoClips = this.Populate(database.ExecuteDataSet(command));
            }

            return videoClips;
        }

        private IList<VideoClip> Populate(DataSet ds)
        {
            var videoClips = new List<VideoClip>();

            if (ds.Tables.Count <= 0 || (ds.Tables[0].Rows.Count <= 0))
            {
                return videoClips;
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                videoClips.Add(
                    new VideoClip
                    {
                        Id = row[Constants.Field_Id].ToInt(),
                        Name = row[Constants.Field_Name].ToString(),
                        Description = row[Constants.Field_Description].ToString(),
                        VideoDefinition = (VideoDefinition)System.Enum.Parse(typeof(VideoDefinition), row[Constants.Field_VideoDefinition].ToString()),
                        VideoStandard = (VideoStandard)System.Enum.Parse(typeof(VideoStandard), row[Constants.Field_VideoStandard].ToString()),
                        StartTime = row[Constants.Field_StartTime].ToString(),
                        EndTime = row[Constants.Field_EndTime].ToString()
                    });
            }

            return videoClips;
        }
    }
}
