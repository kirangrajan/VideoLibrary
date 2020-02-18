using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.DomainModel.Interfaces;
using IMD.VideoLibrary.ViewModel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace IMD.VideoLibrary.ViewModel.Tests
{
    [TestClass]
    public class VideoReelListViewModelTest
    {
        private const string TotalNTSCSDVideoDuration = "00:00:54:08";
        private const string TotalPALSDVideoDuration = "00:02:11:01";

        private Mock<IVideoReelService> _videoReelService;

        private Mock<IVideoReelListViewModel> _videoReelListViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this._videoReelService = new Mock<IVideoReelService>();

            this._videoReelListViewModel = new Mock<IVideoReelListViewModel>();
        }

        [TestMethod]
        public void Test_Total_Duration_All_PAL_SD_Video_Clips()
        {
            // Arrange
            var videoReel = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.PAL,
                    Name = "Video Five",
                    TotalDuration = "00:02:11:01",
                    Id = 1,
                    VideoClips = new List<VideoClip>() { DataHelper.GetaPALSDVideoClip(), DataHelper.GetaPALSDVideoClipB(),  DataHelper.GetaPALSDVideoClipC() }
                },
            };

            this._videoReelService.Setup(x => x.GetAllVideoReels()).Returns(videoReel);

            // Act
            var viewModel = new VideoReelListViewModel(this._videoReelService.Object);
            var result = viewModel.ListAll();

            // Assert
            Assert.AreEqual(viewModel.TotalDuration, TotalPALSDVideoDuration);
            Assert.IsTrue(result.Count > 0);

            this._videoReelService.Verify(x => x.GetAllVideoReels(), Times.Once);
            this._videoReelService.VerifyAll();
        }


        [TestMethod]
        public void Test_Total_Duration_All_NTSC_SD_Video_Clips()
        {
            // Arrange
            var videoReel = new List<VideoReel> 
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

            this._videoReelService.Setup(x => x.GetAllVideoReels()).Returns(videoReel);

            // Act
            var viewModel = new VideoReelListViewModel(this._videoReelService.Object);
            var result = viewModel.ListAll();

            // Assert
            Assert.AreEqual(viewModel.TotalDuration, TotalNTSCSDVideoDuration);
            Assert.IsTrue(result.Count > 0);

            this._videoReelService.Verify(x => x.GetAllVideoReels(), Times.Once);
            this._videoReelService.VerifyAll();
        }
    }
}
