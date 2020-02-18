namespace IMD.VideoLibrary.Utilities
{
    /// <summary>
    /// Extensions for TimeCode
    /// </summary>
    public static class TimeCodeExtensions
    {
        public static int ToInt(this FrameRate frameRate)
        {
            switch (frameRate)
            {
                case FrameRate.FPS25:
                    return 25;
                case FrameRate.FPS30:
                    return 30;
                case FrameRate.Msec:
                    return 1000;
                default:
                    return 1000;
            }
        }

        public static FrameRate ToFrameRate(this int frameRate)
        {
            switch (frameRate)
            {
                case 25:
                    return FrameRate.FPS25;
                case 30:
                    return FrameRate.FPS30;
                case 1000:
                    return FrameRate.Msec;
                default:
                    return FrameRate.Msec;
            }
        }
    }
}
