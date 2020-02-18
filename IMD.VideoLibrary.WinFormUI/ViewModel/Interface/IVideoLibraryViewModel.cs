using System.Collections.Generic;

using IMD.VideoLibrary.DomainModel;

namespace IMD.VideoLibrary.WinFormUI.ViewModel.Interface
{
    public interface IVideoLibraryViewModel
    {
        IList<VideoReel> GetVideoReels { get; }
    }
}
