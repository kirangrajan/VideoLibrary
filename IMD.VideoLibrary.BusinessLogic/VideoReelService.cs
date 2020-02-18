using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.Repository.Interfaces;
using System.Collections.Generic;

namespace IMD.VideoLibrary.BusinessLogic
{
    /// <summary>
    /// Service class for Video Reel
    /// </summary>
    public class VideoReelService : IVideoReelService
    {
        private readonly IVideoReelRepository _repository;

        private readonly IReelClipLinkRepository _reelClipLinkRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoReelService"/> class. 
        /// Constructor
        /// </summary>
        /// <param name="repository"> Video Reel Repository
        /// </param>
        /// <param name="reelClipLinkRepository">Clip reel link repository</param>
        public VideoReelService(IVideoReelRepository repository, IReelClipLinkRepository reelClipLinkRepository)
        {
            this._repository = repository;
            this._reelClipLinkRepository = reelClipLinkRepository;
        }

        /// <summary>
        /// Get all video reels
        /// </summary>
        /// <returns>Collection of video reels</returns>
        public IList<VideoReel> GetAllVideoReels()
        {
            return this._repository.GetVideoReels();
        }

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
        public bool AddClipToReel(VideoReel videoReel, VideoClip videoClip)
        {
            return this._reelClipLinkRepository.AddClipToReel(videoReel, videoClip);
        }

        /// <summary>
        /// Remove a video clip from a reel
        /// </summary>
        /// <param name="videoReel">
        /// The video Reel.
        /// </param>
        /// <param name="videoClip">
        /// video clip
        /// </param>
        public bool RemoveClipFromReel(VideoReel videoReel, VideoClip videoClip)
        {
            return this._reelClipLinkRepository.RemoveClipFromReel(videoReel, videoClip);
        }

        /// <summary>
        /// Get all clips in a reel
        /// </summary>
        /// <param name="reelId"> reel id</param>
        /// <returns>list of video clips</returns>
        public IList<VideoClip> GetClipsForaReel(int reelId)
        {
            return this._repository.GetVideoReel(reelId).VideoClips;
        }

        /// <summary>
        /// Save a video reel
        /// </summary>
        /// <param name="videoReel">video reel</param>
        public bool SaveVideoReel(VideoReel videoReel)
        {
            return this._repository.SaveVideoReel(videoReel);
        }
    }
}
