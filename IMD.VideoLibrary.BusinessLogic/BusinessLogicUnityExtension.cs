using IMD.VideoLibrary.BusinessLogic.Interfaces;

using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.BusinessLogic
{
    /// <summary>
    /// Unity container extension for Business logic layer
    /// </summary>
    public class BusinessLogicUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<IVideoReelService, VideoReelService>(new HierarchicalLifetimeManager());
            this.Container.RegisterType<IVideoClipService, VideoClipService>(new HierarchicalLifetimeManager());
        }
    }
}
