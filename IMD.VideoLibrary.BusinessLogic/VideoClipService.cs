using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.Repository.Interfaces;
using System.Collections.Generic;

namespace IMD.VideoLibrary.BusinessLogic
{
    public class VideoClipService : IVideoClipService
    {
        private readonly IVideoClipRepository _repository;

        public VideoClipService(IVideoClipRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Get a video clip
        /// </summary>
        /// <param name="videoClipId">video clip id</param>
        /// <returns>video clip details</returns>
        public VideoClip GetClip(int videoClipId)
        {
            return this._repository.GetClipDetails(videoClipId);
        }

        /// <summary>
        /// Get All Clips
        /// </summary>
        /// <returns>list of video clips</returns>
        public IList<VideoClip> GetAllClips()
        {
            return this._repository.GetAllClips();
        }
    }
}
