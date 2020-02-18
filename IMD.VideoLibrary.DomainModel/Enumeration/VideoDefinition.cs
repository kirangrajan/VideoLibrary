using System.ComponentModel;

namespace IMD.VideoLibrary.DomainModel.Enumeration
{
    /// <summary>
    /// Video definition enumeration
    /// </summary>
    public enum VideoDefinition
    {
        /// <summary>
        /// Standard definition
        /// </summary>
        [Description("Standard")]
        SD = 1,

        /// <summary>
        /// High definition
        /// </summary>
        [Description("High")]
        HD
    }
}
