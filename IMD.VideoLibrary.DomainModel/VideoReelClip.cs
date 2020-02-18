namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// Video Reel Clip link
    /// </summary>
    public class VideoReelClip : BaseEntity
    {
        /// <summary>
        /// Video Reel
        /// </summary>
        public VideoReel VideoReel { get; set; }

        /// <summary>
        /// Video Clip
        /// </summary>
        public VideoClip VideoClip { get; set; }
    }
}
