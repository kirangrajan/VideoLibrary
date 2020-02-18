using IMD.VideoLibrary.DomainModel.Interfaces;

namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// NTSC Video Clip class
    /// </summary>
    public class NTSCVideoClip : VideoClip
    {
        /// <summary>
        /// Video Standard
        /// </summary>
        public VideoStandardNTSC VideoStandard { get; set; }
    }
}
