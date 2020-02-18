using System.ComponentModel;

namespace IMD.VideoLibrary.Utilities
{
    /// <summary>
    /// Frame rate
    /// </summary>
    public enum FrameRate
    {
        /// <summary>
        ///  PAL frame rate 24 fps
        /// </summary>
        [Description("PAL FPS")]
        FPS25,

        /// <summary>
        /// NTSC frame rate 29.97 fps
        /// </summary>
        [Description("NTSC FPS")]
        FPS30,

        /// <summary>
        /// Milli seconds
        /// </summary>
        [Description("MilliSeconds")]
        Msec
    }
}
