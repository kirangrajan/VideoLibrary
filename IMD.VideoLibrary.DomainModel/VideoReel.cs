using IMD.VideoLibrary.DomainModel.Enumeration;
using System.Collections.Generic;

namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// Video Reel domain model
    /// </summary>
    public class VideoReel : BaseEntity
    {
        /// <summary>
        /// Name of a Video Reel
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of a Video Reel
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// VideoStandard for the Video reel
        /// </summary>
        public VideoStandard VideoStandard { get; set; }

        /// <summary>
        /// Video Definition
        /// </summary>
        public VideoDefinition VideoDefinition { get; set; }

        /// <summary>
        /// Total Duration
        /// </summary>
        public string TotalDuration { get; set; }

        /// <summary>
        /// Video Clips part of the Video reel
        /// </summary>
        public IList<VideoClip> VideoClips { get; set; }
    }
}
