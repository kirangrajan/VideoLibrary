using System.ComponentModel;

namespace IMD.VideoLibrary.DomainModel.Enumeration
{
    public enum VideoStandard
    {
        /// <summary>
        /// Phase Alternating Line
        /// </summary>
        [Description("PhaseAlternatingLine")]
        PAL = 1,

        /// <summary>
        ///  National Television System Committee
        /// </summary>
        [Description("NationalTelevisionSystemCommittee")]
        NTSC
    }
}
