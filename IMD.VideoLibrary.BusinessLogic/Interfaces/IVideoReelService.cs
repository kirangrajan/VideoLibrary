using System.Collections.Generic;

using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.BusinessLogic.Interfaces
{
    /// <summary>
    /// Video reel service contract
    /// </summary>
    public interface IVideoReelService
    {
        /// <summary>
        /// Get all video reels
        /// </summary>
        /// <returns>Collection of video reels</returns>
        IList<VideoReel> GetAllVideoReels();

        /// <summary>
        /// Add a video clip
        /// </summary>
        /// <param name="videoReel">
        /// The video Reel.
        /// </param>
        /// <param name="videoClip">
        /// video clip
        /// </param>
        /// <returns>true/ false</returns>
        bool AddClipToReel(VideoReel videoReel, VideoClip videoClip);

        /// <summary>
        /// Remove a video clip from a reel
        /// </summary>
        /// <param name="videoReel">
        /// The video Reel.
        /// </param>
        /// <param name="videoClip">
        /// video clip
        /// </param>
        bool RemoveClipFromReel(VideoReel videoReel, VideoClip videoClip);

        /// <summary>
        /// Get all clips in a reel
        /// </summary>
        /// <param name="reelId"> reel id</param>
        /// <returns>list of video clips</returns>
        IList<VideoClip> GetClipsForaReel(int reelId);

        /// <summary>
        /// Save a video reel
        /// </summary>
        /// <param name="videoReel">video reel</param>
        bool SaveVideoReel(VideoReel videoReel);
    }
}
