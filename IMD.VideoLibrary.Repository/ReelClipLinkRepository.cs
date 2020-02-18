using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.Repository.Common;
using IMD.VideoLibrary.Repository.Interfaces;
using IMD.VideoLibrary.Utilities;
using System.Data;

namespace IMD.VideoLibrary.Repository
{
    public class ReelClipLinkRepository : IReelClipLinkRepository
    {
        /// <summary>
        /// Add a clip to a reel
        /// </summary>
        /// <param name="reel">reel details</param>
        /// <param name="clip">clip details</param>
        /// <returns>true/ false </returns>
        public bool AddClipToReel(VideoReel reel, VideoClip clip)
        {
            var database = ApplicationDatabase.Create();

            try
            {
                using (var command = database.GetStoredProcCommand(Constants.Procedure_AddClipToReel))
                {
                    database.AddInParameter(command, Constants.Parameter_VideoReelId, DbType.Int32, reel.Id);
                    database.AddInParameter(command, Constants.Parameter_VideoClipId, DbType.Int32, clip.Id);

                    database.ExecuteNonQuery(command);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Remove a clip from a reel
        /// </summary>
        /// <param name="reel">reel details</param>
        /// <param name="clip">clip details</param>
        /// <returns>true/ false </returns>
        public bool RemoveClipFromReel(VideoReel reel, VideoClip clip)
        {
            var database = ApplicationDatabase.Create();

            try
            {
                using (var command = database.GetStoredProcCommand(Constants.Procedure_RemoveClipFromReel))
                {
                    database.AddInParameter(command, Constants.Parameter_VideoReelId, DbType.Int32, reel.Id);
                    database.AddInParameter(command, Constants.Parameter_VideoClipId, DbType.Int32, clip.Id);

                    database.ExecuteNonQuery(command);

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
