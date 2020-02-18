using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.Utilities;
using IMD.VideoLibrary.ViewModel.Interfaces;
using System.Collections.Generic;

namespace IMD.VideoLibrary.ViewModel
{
    /// <summary>
    ///  Video Reel List view model
    /// </summary>
    public class VideoReelListViewModel : IVideoReelListViewModel
    {
        private readonly IVideoReelService _videoReelService;
        private readonly IVideoClipService _videoClipService;

        /// <summary>
        /// List of Video Reels
        /// </summary>
        public IList<VideoReel> VideoReels
        {
            get;
            set;
        }

        /// <summary>
        /// Name of teh video reel
        /// </summary>
        public string VideoReelName
        {
            get;
            set;
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="videoReelService">video reel service</param>
        public VideoReelListViewModel(IVideoReelService videoReelService, IVideoClipService videoClipService)
        {
            this._videoReelService = videoReelService;
            this._videoClipService = videoClipService;
        }

        /// <summary>
        /// List all video reels
        /// </summary>
        /// <returns>collection of video reels</returns>
        public IList<VideoReel> ListAll()
        {
            this.VideoReels = this._videoReelService.GetAllVideoReels();

            foreach (var videoReel in this.VideoReels)
            {
                this.CalculateDuration(videoReel);
            }

            return this.VideoReels;
        }

        /// <summary>
        /// Modify a video Reel
        /// </summary>
        /// <param name="videoReel">video reel</param>
        /// <returns>true if success else false.</returns>
        public bool ModifyReel(VideoReel videoReel)
        {
            return this._videoReelService.SaveVideoReel(videoReel);
        }


        /// <summary>
        /// List all video clips
        /// </summary>
        /// <returns>collection of video clips</returns>
        public IList<VideoClip> ListAllClips()
        {
            return this._videoClipService.GetAllClips();
        }

        private string CalculateDuration(VideoReel videoReel)
        {
            Timecode timeCode = Timecode.FromString("00:00:00:00", videoReel.VideoStandard.FrameRate().ToFrameRate());

            foreach (var videoClip in videoReel.VideoClips)
            {
                if (timeCode != null)
                {
                    timeCode = Timecode.Add(timeCode, Timecode.Subtract(
                    Timecode.FromString(videoClip.EndTime, videoClip.VideoStandard.FrameRate().ToFrameRate()),
                    Timecode.FromString(videoClip.StartTime, videoClip.VideoStandard.FrameRate().ToFrameRate())));
                }
                else
                {
                    timeCode = Timecode.Subtract(
                     Timecode.FromString(videoClip.EndTime, videoClip.VideoStandard.FrameRate().ToFrameRate()),
                     Timecode.FromString(videoClip.StartTime, videoClip.VideoStandard.FrameRate().ToFrameRate()));
                }
            }

            return videoReel.TotalDuration = timeCode.ToString();
        }
    }
}
