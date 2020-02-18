using IMD.VideoLibrary.DomainModel.Interfaces;

namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// Domain model for Video Standard NTSC
    /// </summary>
    public class VideoStandardNTSC : IVideoStandard
    {
        /// <summary>
        /// Video standard Name
        /// </summary>
        public string Name => "NTSC";

        /// <summary>
        /// Number of individual images displayed per second.
        /// Default = 30
        /// </summary>
        public short FramesPerSecond => 30;
    }
}
