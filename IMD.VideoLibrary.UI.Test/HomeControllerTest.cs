using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.DomainModel.Enumeration;
using IMD.VideoLibrary.UI.Controllers;
using IMD.VideoLibrary.ViewModel.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IMD.VideoLibrary.UI.Test
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IVideoReelAddViewModel> _videoReelAddViewModel;
        private Mock<IVideoReelListViewModel> _videoReelListViewModel;

        [TestInitialize]
        public void TestInitialize()
        {
            this._videoReelAddViewModel = new Mock<IVideoReelAddViewModel>();
            this._videoReelListViewModel = new Mock<IVideoReelListViewModel>();
        }

        [TestMethod]
        public void Test_Call_GetVideoReels_Returns_Success_Json_Result()
        {
            // Arrange
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
            var controllerUnderTest = new HomeController(this._videoReelListViewModel.Object, this._videoReelAddViewModel.Object);

            this._videoReelListViewModel.Setup(x => x.ListAll()).Returns(expectedVideoReels);
            this._videoReelListViewModel.Setup(x => x.ListAllClips()).Returns(new List<VideoClip> { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB(), DataHelper.GetaNTSCSDVideoClipC() });

            /// Act
            var actual = controllerUnderTest.GetVideoReels() as JsonResult;

            /// Assert
            Assert.IsNotNull(actual.Data);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data).Count, 1);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].VideoReelVideoClips.Count, 3);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].TotalVideoClips, "3 Clips");
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].VideoReelVideoClips.Count, 3);
        }

        [TestMethod]
        public void Test_Call_GetVideoReels_With_Single_Video_Clip_Returns_Success_Json_Result()
        {
            // Arrange
            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() {  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var controllerUnderTest = new HomeController(this._videoReelListViewModel.Object, this._videoReelAddViewModel.Object);

            this._videoReelListViewModel.Setup(x => x.ListAll()).Returns(expectedVideoReels);
            this._videoReelListViewModel.Setup(x => x.ListAllClips()).Returns(new List<VideoClip> { DataHelper.GetaNTSCSDVideoClipC() });

            /// Act
            var actual = controllerUnderTest.GetVideoReels() as JsonResult;

            /// Assert
            Assert.IsNotNull(actual.Data);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data).Count, 1);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].VideoReelVideoClips.Count, 1);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].TotalVideoClips, "1 Clip");
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].VideoReelVideoClips.Count, 1);
        }

        [TestMethod]
        public void Test_Call_GetVideoClips_Returns_Success_Json_Result()
        {
            // Arrange
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
            var controllerUnderTest = new HomeController(this._videoReelListViewModel.Object, this._videoReelAddViewModel.Object);

            this._videoReelListViewModel.Setup(x => x.ListAllClips()).Returns(new List<VideoClip> { DataHelper.GetaNTSCSDVideoClip(), DataHelper.GetaNTSCSDVideoClipB(), DataHelper.GetaNTSCSDVideoClipC() });

            /// Act
            var actual = controllerUnderTest.GetVideoClips() as JsonResult;

            /// Assert
            Assert.IsNotNull(actual.Data);
            Assert.AreEqual(((List<IMD.VideoLibrary.UI.Models.VideoClip>)actual.Data).Count, 3);
        }

        [TestMethod]
        public void Test_Call_Save_Returns_Success_Json_Result()
        {
            // Arrange
            var expectedUIVideoReel =
                new IMD.VideoLibrary.UI.Models.VideoReel()
                {
                    VideoDefinition = "SD",
                    VideoStandard = "NTSC",
                    Name = "Video Eight Updated",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<IMD.VideoLibrary.UI.Models.VideoClip>() { GetaUINTSCSDVideoClipC() }
                };

            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight Updated",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() {  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var controllerUnderTest = new HomeController(this._videoReelListViewModel.Object, this._videoReelAddViewModel.Object);

            this._videoReelListViewModel.Setup(x => x.ModifyReel(It.IsAny<VideoReel>())).Returns(true);
            this._videoReelListViewModel.Setup(x => x.ListAll()).Returns(expectedVideoReels);
            this._videoReelListViewModel.Setup(x => x.ListAllClips()).Returns(new List<VideoClip> { DataHelper.GetaNTSCSDVideoClipC() });

            /// Act
            var actual = controllerUnderTest.SaveVideoReel(expectedUIVideoReel) as JsonResult;

            /// Assert
            Assert.IsNotNull(actual.Data);
            Assert.AreEqual(1, ((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data).Count);
            Assert.AreEqual(expectedVideoReels[0].Name, ((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].Name);
        }

        [TestMethod]
        public void Test_Call_Add_Video_Clip_Returns_Success_Json_Result()
        {
            // Arrange
            var expectedUIVideoReelToBeAdded =
                new IMD.VideoLibrary.UI.Models.VideoReel()
                {
                    VideoDefinition = "SD",
                    VideoStandard = "NTSC",
                    Name = "Video Eight Updated",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<IMD.VideoLibrary.UI.Models.VideoClip>() { GetaUINTSCSDVideoClipC() }
                };

            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight Updated",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() {  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var controllerUnderTest = new HomeController(this._videoReelListViewModel.Object, this._videoReelAddViewModel.Object);

            this._videoReelAddViewModel.Setup(x => x.AddClipToReel(It.IsAny<VideoReel>(), It.IsAny<int>())).Returns(true);
            this._videoReelListViewModel.Setup(x => x.ListAll()).Returns(expectedVideoReels);
            this._videoReelListViewModel.Setup(x => x.ListAllClips()).Returns(new List<VideoClip> { DataHelper.GetaNTSCSDVideoClipC() });

            /// Act
            var actual = controllerUnderTest.AddClipToVideoReel(expectedUIVideoReelToBeAdded) as JsonResult;

            /// Assert
            Assert.IsNotNull(actual.Data);
            Assert.AreEqual(1, ((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data).Count);
            Assert.AreEqual(expectedVideoReels[0].Name, ((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].Name);
        }

        [TestMethod]
        public void Test_Call_Delete_Video_Clip_Returns_Success_Json_Result()
        {
            // Arrange
            var expectedUIVideoReelToBeRemoved =
                new IMD.VideoLibrary.UI.Models.VideoReel()
                {
                    VideoDefinition = "SD",
                    VideoStandard = "NTSC",
                    Name = "Video Eight Updated",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<IMD.VideoLibrary.UI.Models.VideoClip>() { GetaUINTSCSDVideoClip(), GetaUINTSCSDVideoClipC() }
                };

            var expectedVideoReels = new List<VideoReel> 
            { 
                new VideoReel()
                {
                    VideoDefinition = VideoDefinition.SD,
                    VideoStandard = VideoStandard.NTSC,
                    Name = "Video Eight Updated",
                    TotalDuration = "00:00:54:08",
                    Id = 1,
                    VideoClips = new List<VideoClip>() {  DataHelper.GetaNTSCSDVideoClipC() }
                },
            };

            var controllerUnderTest = new HomeController(this._videoReelListViewModel.Object, this._videoReelAddViewModel.Object);

            this._videoReelAddViewModel.Setup(x => x.AddClipToReel(It.IsAny<VideoReel>(), It.IsAny<int>())).Returns(true);
            this._videoReelListViewModel.Setup(x => x.ListAll()).Returns(expectedVideoReels);
            this._videoReelListViewModel.Setup(x => x.ListAllClips()).Returns(new List<VideoClip> { DataHelper.GetaNTSCSDVideoClipC() });

            /// Act
            var actual = controllerUnderTest.AddClipToVideoReel(expectedUIVideoReelToBeRemoved) as JsonResult;

            /// Assert
            Assert.IsNotNull(actual.Data);
            Assert.AreEqual(1, ((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data).Count);
            Assert.AreEqual(expectedVideoReels[0].Name, ((List<IMD.VideoLibrary.UI.Models.VideoReel>)actual.Data)[0].Name);
        }

        private static IMD.VideoLibrary.UI.Models.VideoClip GetaUINTSCSDVideoClipC()
        {
            return new IMD.VideoLibrary.UI.Models.VideoClip()
            {
                Id = 8,
                Name = "Pepsi",
                Description = "People in the Middles Ages try to entertain their king (Elton John) for a Pepsi. While the first person fails, a mysterious person (Season 1 X Factor winner Melanie Amaro) wins the Pepsi by singing Aretha Franklin's \"Respect\".\" After she wins, she overthrows the king and gives Pepsi to all the town.",
                VideoStandard = "NTSC",
                VideoDefinition = "SD",
                StartTime = "00:00:00:00",
                EndTime = "00:00:20:00"
            };
        }

        private static IMD.VideoLibrary.UI.Models.VideoClip GetaUINTSCSDVideoClip()
        {
            return new IMD.VideoLibrary.UI.Models.VideoClip()
            {
                Id = 2,
                Name = "M&M's",
                Description = "It a party, a brown-shelled M&M is mistaken for being naked. As a result, the red M&M tears off its skin and dances to \"Sexy and I Know It\" by LMFAO",
                VideoStandard = "NTSC",
                VideoDefinition = "SD",
                StartTime = "00:00:00:00",
                EndTime = "00:00:15:27"
            };
        }

    }
}
