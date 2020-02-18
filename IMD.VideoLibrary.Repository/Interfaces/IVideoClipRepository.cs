using System.Collections.Generic;

using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.Repository.Interfaces
{
    /// <summary>
    /// VideoClipRepository Contract
    /// </summary>
    public interface IVideoClipRepository
    {
        /// <summary>
        /// Get All Clips
        /// </summary>
        /// <param name="clipId">Clip Id</param>
        /// <returns>Video Clip details</returns>
        VideoClip GetClipDetails(int clipId);

        /// <summary>
        /// Get All Clips
        /// </summary>
        /// <returns></returns>
        IList<VideoClip> GetAllClips();
    }
}
