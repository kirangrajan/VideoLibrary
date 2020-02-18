using IMD.VideoLibrary.DomainModel.Enumeration;

namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// Abstract class for Video Clip
    /// </summary>
    public class VideoClip: BaseEntity
    {
        /// <summary>
        /// Name of a Video clip
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Brief description of a video clip
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Video Definition
        /// </summary>
        public VideoDefinition VideoDefinition { get; set; }

        /// <summary>
        /// Start Time code details
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// End Time code details
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// Video Standard
        /// </summary>
        public VideoStandard VideoStandard { get; set; }
    }
}
