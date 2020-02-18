using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace IMD.VideoLibrary.BusinessLogic.Test
{
    [TestClass]
    public class VideoReelServiceTest
    {
        private Mock<IVideoReelRepository> _videoReelRepository;
        private Mock<IReelClipLinkRepository> _reelClipLinkRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._videoReelRepository = new Mock<IVideoReelRepository>();
            this._reelClipLinkRepository = new Mock<IReelClipLinkRepository>();
        }

        [TestMethod]
        public void Test_Get_All_Video_Reels()
        {
            /// Arrange
            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB(),  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var serviceToBeTested = new VideoReelService(this._videoReelRepository.Object, this._reelClipLinkRepository.Object);
            this._videoReelRepository.Setup(x => x.GetVideoReels()).Returns(expectedVideoReels);

            /// Act
            var actualVideoReels = serviceToBeTested.GetAllVideoReels();

            /// Assert
            Assert.AreEqual(expectedVideoReels.Count, actualVideoReels.Count);
            Assert.AreEqual(expectedVideoReels[0].Id, actualVideoReels[0].Id);
            Assert.AreEqual(expectedVideoReels[0].Name, actualVideoReels[0].Name);
            Assert.AreEqual(expectedVideoReels[0].Description, actualVideoReels[0].Description);
            Assert.AreEqual(expectedVideoReels[0].VideoDefinition, actualVideoReels[0].VideoDefinition);
            Assert.AreEqual(expectedVideoReels[0].VideoStandard, actualVideoReels[0].VideoStandard);
            Assert.AreEqual(expectedVideoReels[0].TotalDuration, actualVideoReels[0].TotalDuration);

        }

        [TestMethod]
        public void Test_Add_A_New_Clip_To_A_Video_Reel()
        {
            /// Arrange
            var expectedVideoReel =
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB() }
                };

            var serviceToBeTested = new VideoReelService(this._videoReelRepository.Object, this._reelClipLinkRepository.Object);
            this._reelClipLinkRepository.Setup(x => x.AddClipToReel(It.IsAny<VideoReel>(), It.IsAny<VideoClip>())).Returns(true);

            /// Act
            var actual = serviceToBeTested.AddClipToReel(expectedVideoReel, DataHelper.GetaNTSCSDVideoClipC());

            /// Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_Remove_A_Clip_To_A_Video_Reel()
        {
            /// Arrange
            var expectedVideoReel =
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB() }
                };

            var serviceToBeTested = new VideoReelService(this._videoReelRepository.Object, this._reelClipLinkRepository.Object);
            this._reelClipLinkRepository.Setup(x => x.RemoveClipFromReel(It.IsAny<VideoReel>(), It.IsAny<VideoClip>())).Returns(true);

            /// Act
            var actual = serviceToBeTested.RemoveClipFromReel(expectedVideoReel, DataHelper.GetaNTSCSDVideoClipC());

            /// Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_Get_All_Clips_For_A_Video_Reel()
        {
            /// Arrange
            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB(),  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var serviceToBeTested = new VideoReelService(this._videoReelRepository.Object, this._reelClipLinkRepository.Object);
            this._videoReelRepository.Setup(x => x.GetVideoReel(It.IsAny<int>())).Returns(expectedVideoReels[0]);

            /// Act
            var actualVideoClipsForAReel = serviceToBeTested.GetClipsForaReel(It.IsAny<int>());

            /// Assert
            Assert.AreEqual(expectedVideoReels[0].VideoClips.Count, 3);
            Assert.AreEqual(expectedVideoReels[0].VideoClips, actualVideoClipsForAReel);

        }

        [TestMethod]
        public void Test_Modify_And_Save_A_Video_Reel()
        {
            /// Arrange
            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB(),  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var serviceToBeTested = new VideoReelService(this._videoReelRepository.Object, this._reelClipLinkRepository.Object);
            this._videoReelRepository.Setup(x => x.SaveVideoReel(It.IsAny<VideoReel>())).Returns(true);

            /// Act
            var actual = serviceToBeTested.SaveVideoReel(It.IsAny<VideoReel>());

            /// Assert
            Assert.AreEqual(true, actual);
        }
    }
}
