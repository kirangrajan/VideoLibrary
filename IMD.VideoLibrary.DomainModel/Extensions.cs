using IMD.VideoLibrary.DomainModel.Enumeration;

namespace IMD.VideoLibrary.DomainModel
{
    public static class Extensions
    {
        public static int FrameRate(this VideoStandard videoStandard)
        {
            return videoStandard == VideoStandard.NTSC ? 30 : 25;
        }
    }
}
