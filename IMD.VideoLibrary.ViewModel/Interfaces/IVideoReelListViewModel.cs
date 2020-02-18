using System.Collections.Generic;

using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.ViewModel.Interfaces
{
    /// <summary>
    /// Video Reel List View Model contract
    /// </summary>
    public interface IVideoReelListViewModel
    {
        /// <summary>
        /// List all video reels
        /// </summary>
        /// <returns>collection of video reels</returns>
        IList<VideoReel> ListAll();

        /// <summary>
        /// Modify a video Reel
        /// </summary>
        /// <param name="videoReel">video reel</param>
        /// <returns>true if success else false.</returns>
        bool ModifyReel(VideoReel videoReel);

        /// <summary>
        /// List all video clips
        /// </summary>
        /// <returns>collection of video clips</returns>
        IList<VideoClip> ListAllClips();
    }
}
