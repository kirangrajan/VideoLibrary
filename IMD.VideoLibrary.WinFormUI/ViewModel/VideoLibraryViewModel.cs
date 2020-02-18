using System.Collections.Generic;

using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.WinFormUI.ViewModel.Interface;

namespace IMD.VideoLibrary.WinFormUI.ViewModel
{
    public class VideoLibraryViewModel : IVideoLibraryViewModel
    {
        private readonly IVideoClipService _videoClipService;
        private readonly IVideoReelService _videoReelService;

        public VideoLibraryViewModel(IVideoClipService videoClipService, IVideoReelService videoReelService)
        {
            this._videoClipService = videoClipService;
            this._videoReelService = videoReelService;
        }

        public IList<VideoReel> GetVideoReels
        {
            get
            {
                return this._videoReelService.GetAllVideoReels();
            }
        }
    }
}
