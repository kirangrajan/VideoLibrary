using IMD.VideoLibrary.DomainModel.Interfaces;

namespace IMD.VideoLibrary.DomainModel
{
    /// <summary>
    /// PAL Video Clip class
    /// </summary>
    public class PALVideoClip : VideoClip
    {
        /// <summary>
        /// Video Standard
        /// </summary>
        public VideoStandardPAL VideoStandard { get; set; }
    }
}
