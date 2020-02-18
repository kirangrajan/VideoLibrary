using IMD.VideoLibrary.BusinessLogic.Interfaces;
using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.Utilities;
using IMD.VideoLibrary.ViewModel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace IMD.VideoLibrary.ViewModel.Test
{
    [TestClass]
    public class VideoReelAddViewModelTest
    {
        private Mock<IVideoReelService> _videoReelService;

        private Mock<IVideoClipService> _videoClipService;

        private Mock<IVideoReelAddViewModel> _videoReelAddViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this._videoReelService = new Mock<IVideoReelService>();
            this._videoClipService = new Mock<IVideoClipService>();

            this._videoReelAddViewModel = new Mock<IVideoReelAddViewModel>();
        }

        [TestMethod]
        public void Test_Add_NTSC_SD_VideoClip_To_A_PAL_SD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.SD,
                VideoStandard = VideoStandard.PAL,
                Name = "Video One",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS25), Timecode.FromString("00:00:00:00", FrameRate.FPS25)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaPALSDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(2)).Returns(DataHelper.GetaNTSCSDVideoClip());

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            var result = viewModel.AddClipToReel(videoReel, 2);

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Standards do not match.");
            Assert.IsFalse(result);

            this._videoClipService.VerifyAll();
        }

        [TestMethod]
        public void Test_Add_NTSC_HD_VideoClip_To_A_PAL_SD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.SD,
                VideoStandard = VideoStandard.PAL,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS25), Timecode.FromString("00:00:00:00", FrameRate.FPS25)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaPALSDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(2)).Returns(DataHelper.GetaNTSCHDVideoClip());

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            var result = viewModel.AddClipToReel(videoReel, 2);

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Definitions do not match.");
            Assert.IsFalse(result);

            this._videoClipService.VerifyAll();
        }

        [TestMethod]
        public void Test_Add_NTSC_HD_VideoClip_To_A_PAL_HD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.PAL,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS25), Timecode.FromString("00:00:00:00", FrameRate.FPS25)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(4)).Returns(DataHelper.GetaNTSCHDVideoClip());

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            var result = viewModel.AddClipToReel(videoReel, 4);
            viewModel.VideoClip = DataHelper.GetaNTSCHDVideoClip();

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Standards do not match.");
            Assert.IsFalse(result);

            this._videoClipService.VerifyAll();
        }

        [TestMethod]
        public void Test_Add_Existing_PAL_HD_VideoClip_To_A_PAL_HD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.PAL,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS25), Timecode.FromString("00:00:00:00", FrameRate.FPS25)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(3))
                .Returns(DataHelper.GetaPALHDVideoClip());
            this._videoReelService.Setup(x => x.GetClipsForaReel(It.IsAny<int>())).Returns(new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() });

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            viewModel.VideoClips = new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() };
            viewModel.VideoClip = DataHelper.GetaPALHDVideoClip();

            var result = viewModel.AddClipToReel(videoReel, 3);

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Clip already present.");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_Add_PAL_HD_VideoClip_To_A_PAL_HD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.PAL,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS25), Timecode.FromString("00:00:00:00", FrameRate.FPS25)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(3))
                .Returns(
                    new VideoClip()
                    {
                        Id = 4,
                        Name = "Captain America: The First Avenger New",
                        Description = "Video Promo",
                        VideoStandard = VideoStandard.PAL,
                        VideoDefinition = VideoDefinition.HD,
                        StartTime = "00:00:00:00",
                        EndTime = "00:00:20:10"
                    });

            this._videoReelService.Setup(x => x.GetClipsForaReel(It.IsAny<int>())).Returns(new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() });

            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            viewModel.VideoClips = new List<VideoClip>() { DataHelper.GetaPALHDVideoClip() };
            viewModel.VideoClip = new VideoClip()
            {
                Id = 4,
                Name = "Captain America: The First Avenger New",
                Description = "Video Promo",
                VideoStandard = VideoStandard.PAL,
                VideoDefinition = VideoDefinition.HD,
                StartTime = "00:00:00:00",
                EndTime = "00:00:20:10"
            };


            // Act
            var result = viewModel.AddClipToReel(videoReel, 3);

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, true);
            Assert.AreEqual(viewModel.ErrorMessage, string.Empty);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_Add_NTSC_SD_VideoClip_To_A_NTSC_HD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                Name = "Video One",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS30), Timecode.FromString("00:00:00:00", FrameRate.FPS30)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCSDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(2)).Returns(DataHelper.GetaNTSCSDVideoClip());

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            var result = viewModel.AddClipToReel(videoReel, 2);
            viewModel.VideoClip = DataHelper.GetaNTSCSDVideoClip();

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Definitions do not match.");
            Assert.IsFalse(result);

            this._videoClipService.VerifyAll();
        }

        [TestMethod]
        public void Test_Add_PAL_SD_VideoClip_To_A_NTSC_HD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS30), Timecode.FromString("00:00:00:00", FrameRate.FPS30)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaPALSDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(1)).Returns(DataHelper.GetaPALSDVideoClip());

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            var result = viewModel.AddClipToReel(videoReel, 1);
            viewModel.VideoClip = DataHelper.GetaPALSDVideoClip();

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Definitions do not match.");
            Assert.IsFalse(result);

            this._videoClipService.VerifyAll();
        }

        [TestMethod]
        public void Test_Add_PAL_HD_VideoClip_To_A_NTSC_HD_VideoReel()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS25), Timecode.FromString("00:00:00:00", FrameRate.FPS25)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCHDVideoClip() }
            };

            this._videoClipService.Setup(x => x.GetClip(3)).Returns(DataHelper.GetaPALHDVideoClip());

            // Act
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            var result = viewModel.AddClipToReel(videoReel, 3);
            viewModel.VideoClip = DataHelper.GetaPALHDVideoClip();

            // Assert
            Assert.AreEqual(viewModel.CanAddClipToReel, false);
            Assert.AreEqual(viewModel.ErrorMessage, "Add failed.Video Standards do not match.");
            Assert.IsFalse(result);

            this._videoClipService.VerifyAll();
        }

        [TestMethod]
        public void Test_Get_Video_Clip_Details()
        {
            // Arrange
            var videoReel = new VideoReel()
            {
                VideoDefinition = VideoDefinition.HD,
                VideoStandard = VideoStandard.NTSC,
                Name = "Video Two",
                TotalDuration = Timecode.Subtract(Timecode.FromString("00:00:20:10", FrameRate.FPS30), Timecode.FromString("00:00:00:00", FrameRate.FPS30)).ToString(),
                Id = 1,
                VideoClips = new List<VideoClip>() { DataHelper.GetaNTSCHDVideoClip() }
            };
            this._videoClipService.Setup(x => x.GetClip(3)).Returns(DataHelper.GetaPALHDVideoClip());
            var viewModel = new VideoReelAddViewModel(this._videoReelService.Object, this._videoClipService.Object);
            viewModel.GetVideoClipDetails(3);

            Assert.AreEqual(viewModel.VideoClip.Id, 3);
            Assert.AreEqual(viewModel.VideoClip.VideoStandard, VideoStandard.PAL);
            Assert.AreEqual(viewModel.VideoClip.VideoDefinition, VideoDefinition.HD);
            Assert.AreEqual(viewModel.VideoClip.Description, "Video Promo");
            Assert.AreEqual(viewModel.VideoClip.Name, "Captain America: The First Avenger");
        }
    }
}
