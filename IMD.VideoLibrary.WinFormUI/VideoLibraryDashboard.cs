using System.Windows.Forms;

using IMD.VideoLibrary.BusinessLogic.Interfaces;

namespace IMD.VideoLibrary.WinFormUI
{
    /// <summary>
    /// The video library dashboard.
    /// </summary>
    public partial class VideoLibraryDashboard : Form
    {
        private readonly IVideoReelService _videoReelService;
        private readonly IVideoClipService _videoClipService;
        public VideoLibraryDashboard()
        {
            this.InitializeComponent();
        }

        public VideoLibraryDashboard(IVideoReelService videoReelService, IVideoClipService videoClipService)
        {
            this._videoReelService = videoReelService;
            this._videoClipService = videoClipService;
            this.InitializeComponent();
        }
    }
}
