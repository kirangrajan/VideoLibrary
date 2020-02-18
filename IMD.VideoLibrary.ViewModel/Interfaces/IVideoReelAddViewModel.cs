using System.Collections.Generic;

using IMD.VideoLibrary.BusinessLogic;
using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.ViewModel.Interfaces
{
    /// <summary>
    /// Contract for Video Reel Add view model
    /// </summary>
    public interface IVideoReelAddViewModel
    {
        /// <summary>
        /// Error Message
        /// </summary>
        string ErrorMessage { get; set; }

        /// <summary>
        /// Can Add Clip To Reel
        /// </summary>
        bool CanAddClipToReel { get; }

        /// <summary>
        /// Add Clip To Reel
        /// </summary>
        /// <param name="videoReel">Video Reel</param>
        /// <param name="clipId">Video clip Id</param>
        /// <returns>true in case of success</returns>
        bool AddClipToReel(VideoReel videoReel, int clipId);

        /// <summary>
        /// Remove Clip From a Reel
        /// </summary>
        /// <param name="videoReel">Video Reel</param>
        /// <param name="clipId">Video clip Id</param>
        /// <returns>true in case of success</returns>
        bool RemoveClipFromReel(VideoReel videoReel, int clipId);

        /// <summary>
        /// GetVideoClip
        /// </summary>
        /// <param name="clipId">Video clip Id</param>
        /// <returns>true in case of success</returns>
        VideoClip GetVideoClipDetails( int clipId);

        /// <summary>
        /// Video Clips
        /// </summary>
        /// <returns>collection of VideoClips</returns>
        IList<VideoClip> VideoClips { get; set; }

        /// <summary>
        /// Video Clip
        /// </summary>
        VideoClip VideoClip { get; set; }
    }
}
