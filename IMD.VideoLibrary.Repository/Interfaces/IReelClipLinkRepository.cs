using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.Repository.Interfaces
{
    public interface IReelClipLinkRepository
    {
        /// <summary>
        /// Add a clip to a reel
        /// </summary>
        /// <param name="reel">reel details</param>
        /// <param name="clip">clip details</param>
        /// <returns>true/ false </returns>
        bool AddClipToReel(VideoReel reel, VideoClip clip);

        /// <summary>
        /// Remove a clip from a reel
        /// </summary>
        /// <param name="reel">reel details</param>
        /// <param name="clip">clip details</param>
        /// <returns>true/ false </returns>
        bool RemoveClipFromReel(VideoReel reel, VideoClip clip);
    }
}
