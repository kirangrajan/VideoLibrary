using System;
using System.Text.RegularExpressions;

namespace IMD.VideoLibrary.Utilities
{
    public class Timecode
    {
        private const string TimeCodePattern = @"^(?<hours>[0-2][0-9]):(?<minutes>[0-5][0-9]):(?<seconds>[0-5][0-9])[:|;|\.](?<frames>[0-9]{2,3})$";

        private const int SecondsInHour = 3600;
        private const int SecondsInMinutes = 60;

        private readonly int _frameRate;

        private Timecode(FrameRate frameRate)
        {
            this._frameRate = frameRate.ToInt();
        }

        public int TotalFrames { get; set; }

        public int Hours { get; set; }

        public int Minutes { get; set; }

        public int Seconds { get; set; }

        public int Frames { get; set; }

        public static Timecode FromString(string input, FrameRate frameRate)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(input);
            }

            Validate(frameRate);

            var regexTimeCode = new Regex(TimeCodePattern);

            var match = regexTimeCode.Match(input);
            if (!match.Success)
            {
                throw new ArgumentException("Input text was not in valid timecode format.", input);
            }

            var tc = new Timecode(frameRate)
            {
                Hours = int.Parse(match.Groups["hours"].Value),
                Minutes = int.Parse(match.Groups["minutes"].Value),
                Seconds = int.Parse(match.Groups["seconds"].Value),
                Frames = int.Parse(match.Groups["frames"].Value)
            };

            tc.CalculateTotalFrames();

            return tc;
        }

        /// <summary>
        /// Convert timecode to a timespan
        /// </summary>
        /// <returns>Time span object</returns>
        public TimeSpan ToTimeSpan(FrameRate frameRate)
        {
            var tc = new Timecode(frameRate) { TotalFrames = this.TotalFrames };
            tc.UpdateByTotalFrames();
            return new TimeSpan(0, tc.Hours, tc.Minutes, tc.Seconds, tc.Frames);
        }

        /// <summary>
        /// Convert to Timecode from Total Frames
        /// </summary>
        /// <param name="totalFrames">total frames</param>
        /// <param name="frameRate"> framerate</param>
        /// <returns>time code object</returns>
        public static Timecode FromFrames(int totalFrames, FrameRate frameRate)
        {
            Validate(frameRate);

            var tc = new Timecode(frameRate) { TotalFrames = totalFrames };
            tc.UpdateByTotalFrames();

            return tc;
        }

        public override string ToString()
        {
            var frameSeparator = ":";
            return
                string.Format("{0}:{1}:{2}{3}{4}", this.Hours.ToString("D2"), this.Minutes.ToString("D2"), this.Seconds.ToString("D2"), frameSeparator, this.Frames.ToString("D2"));
        }

        /// <summary>
        /// Adds two timecodes.
        /// </summary>
        /// <param name="timecodeA">Timecode A</param>
        /// <param name="timecodeB">Timecode B</param>
        /// <returns>new time code</returns>
        public static Timecode Add(Timecode timecodeA, Timecode timecodeB)
        {
            if (timecodeA._frameRate != timecodeB._frameRate)
            {
                throw new InvalidOperationException("Cannot add two timecodes with different framerates.");
            }

            return FromFrames(timecodeA.TotalFrames + timecodeB.TotalFrames, timecodeA._frameRate.ToFrameRate());
        }

        /// <summary>
        /// Subtracts two timecodes.
        /// </summary>
        /// <param name="timecodeA">Timecode A</param>
        /// <param name="timecodeB">Timecode B</param>
        /// <returns>new time code</returns>
        /// <remarks>If the second timecode has fewer frames than the first, it is presumed to have rolled over the 24 hour mark and therefore be conceptually greater than the first.</remarks>
        public static Timecode Subtract(Timecode timecodeA, Timecode timecodeB)
        {
            if (timecodeA._frameRate != timecodeB._frameRate)
            {
                throw new InvalidOperationException("Cannot subtract two timecodes with different framerates.");
            }

            var totalFramesA = timecodeA.TotalFrames;
            var totalFramesB = timecodeB.TotalFrames;

            if (totalFramesA < totalFramesB)
            {
                totalFramesA += timecodeA.OneDay();
            }

            return FromFrames(totalFramesA - totalFramesB, timecodeA._frameRate.ToFrameRate());
        }

        private static void Validate(FrameRate frameRate)
        {
            if (!Enum.IsDefined(typeof(FrameRate), frameRate))
            {
                throw new ArgumentOutOfRangeException(
                    frameRate.ToString(),
                    "Value should be defined in the FrameRate enum.");
            }
        }

        /// <summary>
        /// Get Frame per day
        /// </summary>
        /// <param name="framesPerSecond">frame per second</param>
        /// <returns>Frame per day</returns>
        private static int FramesPerDay(int framesPerSecond)
        {
            return framesPerSecond * 60 * 60 * 24;
        }

        private void CalculateTotalFrames()
        {
            var frames = this.Hours * SecondsInHour;
            frames += this.Minutes * SecondsInMinutes;
            frames += this.Seconds;
            frames *= this._frameRate;
            frames += this.Frames;

            this.TotalFrames = frames;
        }

        private void UpdateByTotalFrames()
        {
            var frameCount = this.TotalFrames;

            this.Hours = frameCount / (SecondsInHour * this._frameRate);

            if (this.Hours > 23)
            {
                this.Hours %= 24;
                frameCount -= 23 * SecondsInHour * this._frameRate;
            }

            this.Minutes = frameCount % (SecondsInHour * this._frameRate) / (SecondsInMinutes * this._frameRate);

            this.Seconds = frameCount % (SecondsInHour * this._frameRate) % (SecondsInMinutes * this._frameRate) / this._frameRate;

            this.Frames = frameCount % (SecondsInHour * this._frameRate) % (SecondsInMinutes * this._frameRate) % this._frameRate;
        }

        /// <summary>
        /// The total number of frames in one day, for this timecode's framerate.
        /// </summary>
        /// <returns>Frames per day</returns>
        private int OneDay()
        {
            return FramesPerDay(this._frameRate);
        }
    }
}
