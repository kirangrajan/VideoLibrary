using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.Repository.Common;
using IMD.VideoLibrary.Repository.Interfaces;
using IMD.VideoLibrary.Utilities;
using System.Collections.Generic;
using System.Data;

namespace IMD.VideoLibrary.Repository
{
    public class VideoReelRepository : IVideoReelRepository
    {
        /// <summary>
        /// Get a Video reel
        /// </summary>
        /// <param name="reelId">
        /// The reel Id.
        /// </param>
        /// <returns>
        /// video reel
        /// </returns>
        public VideoReel GetVideoReel(int reelId)
        {
            IList<VideoReel> videoReels;

            var database = ApplicationDatabase.Create();

            using (var command = database.GetStoredProcCommand(Constants.Procedure_GetVideoReel))
            {
                database.AddInParameter(command, Constants.Parameter_VideoReelId, DbType.Int32, reelId);

                videoReels = this.Populate(database.ExecuteDataSet(command));
            }

            return videoReels.Count > 0 ? videoReels[0] : null;
        }

        /// <summary>
        /// Get All Video reels
        /// </summary>
        /// <returns>collection of video reels</returns>
        public IList<VideoReel> GetVideoReels()
        {
            IList<VideoReel> videoReels;

            var database = ApplicationDatabase.Create();

            using (var command = database.GetStoredProcCommand(Constants.Procedure_GetAllVideoReels))
            {
                videoReels = this.Populate(database.ExecuteDataSet(command));
            }

            return videoReels;
        }

        /// <summary>
        /// Save a video reel Name
        /// </summary>
        /// <param name="videoReel">video reel</param>
        public bool SaveVideoReel(VideoReel videoReel)
        {
            var database = ApplicationDatabase.Create();

            try
            {
                using (var command = database.GetStoredProcCommand(Constants.Procedure_SaveVideoReel))
                {
                    database.AddInParameter(command, Constants.Parameter_VideoReelName, DbType.String, videoReel.Name);
                    database.AddInParameter(command, Constants.Parameter_VideoReelId, DbType.Int32, videoReel.Id);
                    database.ExecuteNonQuery(command);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private IList<VideoReel> Populate(DataSet ds)
        {
            var reels = new List<VideoReel>();
            var clips = new List<VideoClip>();

            var reelClips = new List<VideoReelClip>();

            if (ds.Tables.Count <= 0 || (ds.Tables[0].Rows.Count <= 0) || (ds.Tables[1].Rows.Count <= 0))
            {
                return reels;
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                reels.Add(
                    new VideoReel
                    {
                        Id = row[Constants.Field_Id].ToInt(),
                        Name = row[Constants.Field_Name].ToString(),
                        Description = row[Constants.Field_Description].ToString(),
                        VideoDefinition = (VideoDefinition)System.Enum.Parse(typeof(VideoDefinition), row[Constants.Field_VideoDefinition].ToString()),
                        VideoStandard = (VideoStandard)System.Enum.Parse(typeof(VideoStandard), row[Constants.Field_VideoStandard].ToString()),
                        TotalDuration = row[Constants.Field_TotalDuration].ToString(),
                        VideoClips = new List<VideoClip>()
                    });
            }

            foreach (DataRow row in ds.Tables[1].Rows)
            {
                clips.Add(
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

            foreach (DataRow row in ds.Tables[2].Rows)
            {
                reelClips.Add(
                    new VideoReelClip
                    {
                        Id = row[Constants.Field_Id].ToInt(),
                        VideoReel = new VideoReel() { Id = row[Constants.Field_VideoReelId].ToInt() },
                        VideoClip = new VideoClip() { Id = row[Constants.Field_VideoClipId].ToInt() }
                    });
            }

            if (reelClips.Count <= 0)
            {
                return reels;
            }


            foreach (var reel in reels)
            {
                foreach (var reelClip in reelClips)
                {
                    if (reel.Id == reelClip.VideoReel.Id)
                    {
                        reel.VideoClips.Add(clips.Find(p => p.Id == reelClip.VideoClip.Id));
                    }
                }

            }

            //var foundReel = false;
            //foreach (var clip in clips)
            //{
            //    foreach (var reelId in from reelClip in reelClips where reelClip.Id == clip.Id select reelClip.VideoReel.Id)
            //    {
            //        foreach (var reel in reels.Where(reel => reel.Id == reelId))
            //        {
            //            foundReel = true;
            //            reel.VideoClips.Add(clip);
            //            break;
            //        }

            //        if (foundReel)
            //        {
            //            break;
            //        }
            //    }
            //}

            return reels;
        }
    }
}
