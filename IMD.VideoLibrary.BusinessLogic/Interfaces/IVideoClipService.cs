using System.Collections.Generic;

using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.BusinessLogic.Interfaces
{
    public interface IVideoClipService
    {
        /// <summary>
        /// Get a video clip
        /// </summary>
        /// <param name="videoClipId">video clip id</param>
        /// <returns>video clip details</returns>
        VideoClip GetClip(int videoClipId);

        /// <summary>
        /// Get All Clips
        /// </summary>
        /// <returns>list of video clips</returns>
        IList<VideoClip> GetAllClips();
    }
}
