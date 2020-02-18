using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMD.VideoLibrary.UI.Models
{
    public class VideoClip
    {
        /// <summary>
        /// Video Clip Identifier
        /// </summary>
        public int Id { get; set; }

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
        public string VideoDefinition { get; set; }

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
        public string VideoStandard { get; set; }
    }
}