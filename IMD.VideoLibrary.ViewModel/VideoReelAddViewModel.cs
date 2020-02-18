using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.Utilities;
using IMD.VideoLibrary.ViewModel.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace IMD.VideoLibrary.ViewModel
{
    /// <summary>
    /// Video Ree lView Model
    /// </summary>
    public class VideoReelAddViewModel : IVideoReelAddViewModel
    {
        private readonly IVideoReelService _videoReelService;
        private readonly IVideoClipService _videoClipService;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoReelAddViewModel"/> class. 
        /// Constructor
        /// </summary>
        /// <param name="videoReelService">
        /// The video Reel Service.
        /// </param>
        /// <param name="videoClipService">
        /// Video clip service 
        /// </param>
        /// <param name="videoReel">
        /// The video Reel.
        /// </param>
        /// <param name="clipId">
        /// The clip Id.
        /// </param>
        public VideoReelAddViewModel(IVideoReelService videoReelService, IVideoClipService videoClipService)
        {
            this._videoReelService = videoReelService;
            this._videoClipService = videoClipService;
        }

        public string ErrorMessage { get; set; }

        /// <summary>
        /// Video Clips
        /// </summary>
        /// <returns>collection of VideoClips</returns>
        public IList<VideoClip> VideoClips { get; set; }

        public VideoClip VideoClip { get; set; }

        public bool CanAddClipToReel
        {
            get
            {
                this.ErrorMessage = string.Empty;

                if (this.VideoClip.VideoDefinition != this.VideoReel.VideoDefinition)
                {
                    this.ErrorMessage = "Add failed.Video Definitions do not match.";
                    return false;
                }

                if (this.VideoClip.VideoStandard != this.VideoReel.VideoStandard)
                {
                    this.ErrorMessage = "Add failed.Video Standards do not match.";
                    return false;
                }

                if (this.VideoClips.All(x => x.Id != this.VideoClip.Id))
                {
                    return true;
                }

                this.ErrorMessage = "Add failed.Video Clip already present.";
                return false;
            }
        }

        private VideoReel VideoReel { get; set; }

        /// <summary>
        /// Add Clip To Reel
        /// </summary>
        /// <param name="videoReel">Video Reel</param>
        /// <param name="clipId">Video clip Id</param>¬
        /// <returns>true in case of success</returns>
        public bool AddClipToReel(VideoReel videoReel, int clipId)
        {
            this.VideoReel = videoReel;
            this.GetVideoClipDetails(clipId);

            this.VideoClips = videoReel.VideoClips = this.GetVideoClipsForVideoReel(VideoReel);

            if (!this.CanAddClipToReel)
            {
                return false;
            }

            this._videoReelService.AddClipToReel(this.VideoReel, new VideoClip { Id = clipId });
            this.CalculateDuratiion(this.VideoReel);

            return true;
        }

        /// <summary>
        /// Remove Clip From a Reel
        /// </summary>
        /// <param name="videoReel">Video Reel</param>
        /// <param name="clipId">Video clip Id</param>
        /// <returns>true in case of success</returns>
        public bool RemoveClipFromReel(VideoReel videoReel, int clipId)
        {
            this.VideoReel = videoReel;
            return this._videoReelService.RemoveClipFromReel(videoReel, new VideoClip { Id = clipId });
        }

        /// <summary>
        /// GetVideoClip
        /// </summary>
        /// <param name="clipId">Video clip Id</param>
        /// <returns>true in case of success</returns>
        public VideoClip GetVideoClipDetails(int clipId)
        {
            return this.VideoClip = this._videoClipService.GetClip(clipId);
        }


        private IList<VideoClip> GetVideoClipsForVideoReel(VideoReel videoReel)
        {
            return this._videoReelService.GetClipsForaReel(videoReel.Id);
        }

        private string CalculateDuratiion(VideoReel videoReel)
        {
            Timecode timeCode = null;
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
