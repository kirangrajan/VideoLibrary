using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMD.VideoLibrary.UI.Models
{
    public class VideoReel
    {
        /// <summary>
        /// VideoReel Identifier
        /// </summary>
        public int Id { get; set; }

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
        public string VideoStandard { get; set; }

        /// <summary>
        /// Video Definition
        /// </summary>
        public string VideoDefinition { get; set; }

        /// <summary>
        /// Total Duration
        /// </summary>
        public string TotalDuration { get; set; }

        /// <summary>
        /// Video Clips part of the Video reel
        /// </summary>
        public IList<VideoClip> VideoReelVideoClips { get; set; }

        /// <summary>
        /// Video Clips 
        /// </summary>
        public IList<VideoClip> VideoClips { get; set; }
        /// <summary>
        /// Video Clip Id
        /// </summary>
        public int SelectedVideoClipId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TotalVideoClips
        {
            get
            {
                return VideoReelVideoClips.Count <= 1 ? string.Format("{0} Clip", VideoReelVideoClips.Count) : string.Format("{0} Clips", VideoReelVideoClips.Count);
            }
        }
        /// <summary>
        /// Error message if any
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}