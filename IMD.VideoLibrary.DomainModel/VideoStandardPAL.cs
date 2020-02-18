using IMD.VideoLibrary.DomainModel.Interfaces;

namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// Domain model for Video Standard PAL
    /// </summary>
    public class VideoStandardPAL : IVideoStandard
    {
        /// <summary>
        /// Video standard Name
        /// </summary>
        public string Name => "PAL";

        /// <summary>
        /// Number of individual images displayed per second.
        /// Default = 25
        /// </summary>
        public short FramesPerSecond => 25;
    }
}
