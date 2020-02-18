using IMD.VideoLibrary.DomainModel;
using IMD.VideoLibrary.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace IMD.VideoLibrary.BusinessLogic.Test
{
    [TestClass]
    public class VideoClipServiceTest
    {
        private Mock<IVideoClipRepository> _videoClipRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._videoClipRepository = new Mock<IVideoClipRepository>();
        }

        [TestMethod]
        public void Test_GetClip_For_A_Given_Clip_Id()
        {
            /// Arrange
            var expectedVideoClip = DataHelper.GetaNTSCHDVideoClip();
            var serviceToBeTested = new VideoClipService(this._videoClipRepository.Object);
            this._videoClipRepository.Setup(x => x.GetClipDetails(It.IsAny<int>())).Returns(expectedVideoClip);

            /// Act
            var actualVideoClip = serviceToBeTested.GetClip(It.IsAny<int>());

            /// Assert
            Assert.AreEqual(expectedVideoClip.Id, actualVideoClip.Id);
            Assert.AreEqual(expectedVideoClip.Name, actualVideoClip.Name);
            Assert.AreEqual(expectedVideoClip.Description, actualVideoClip.Description);
            Assert.AreEqual(expectedVideoClip.VideoDefinition, actualVideoClip.VideoDefinition);
            Assert.AreEqual(expectedVideoClip.VideoStandard, actualVideoClip.VideoStandard);
            Assert.AreEqual(expectedVideoClip.EndTime, actualVideoClip.EndTime);
            Assert.AreEqual(expectedVideoClip.StartTime, actualVideoClip.StartTime);
        }

        [TestMethod]
        public void Test_Get_All_Clips()
        {
            /// Arrange
            var expectedVideoClips = new List<VideoClip> { DataHelper.GetaPALSDVideoClip(), DataHelper.GetaPALSDVideoClipB(), DataHelper.GetaPALSDVideoClipC() };
            var serviceToBeTested = new VideoClipService(this._videoClipRepository.Object);
            this._videoClipRepository.Setup(x => x.GetAllClips()).Returns(expectedVideoClips);

            /// Act
            var actualVideoClips = serviceToBeTested.GetAllClips();

            /// Assert
            Assert.AreEqual(expectedVideoClips.Count, actualVideoClips.Count);
            Assert.AreEqual(expectedVideoClips[0].Id, actualVideoClips[0].Id);
            Assert.AreEqual(expectedVideoClips[0].Name, actualVideoClips[0].Name);
            Assert.AreEqual(expectedVideoClips[0].Description, actualVideoClips[0].Description);
            Assert.AreEqual(expectedVideoClips[0].VideoDefinition, actualVideoClips[0].VideoDefinition);
            Assert.AreEqual(expectedVideoClips[0].VideoStandard, actualVideoClips[0].VideoStandard);
            Assert.AreEqual(expectedVideoClips[0].EndTime, actualVideoClips[0].EndTime);
            Assert.AreEqual(expectedVideoClips[0].StartTime, actualVideoClips[0].StartTime);
        }
    }
}
