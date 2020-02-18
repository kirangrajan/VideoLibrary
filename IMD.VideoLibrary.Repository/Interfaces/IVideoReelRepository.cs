using System.Collections.Generic;

using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.Repository.Interfaces
{
    public interface IVideoReelRepository
    {
        /// <summary>
        /// Get All Video reels
        /// </summary>
        /// <returns>collection of video reels</returns>
        IList<VideoReel> GetVideoReels();

        /// <summary>
        /// Get a Video reel
        /// </summary>
        /// <param name="reelId">
        /// The reel Id.
        /// </param>
        /// <returns>
        /// video reel
        /// </returns>
        VideoReel GetVideoReel(int reelId);

         /// <summary>
        /// Save a video reel
        /// </summary>
        /// <param name="videoReel">video reel</param>
        bool SaveVideoReel(VideoReel videoReel);
    }
}
