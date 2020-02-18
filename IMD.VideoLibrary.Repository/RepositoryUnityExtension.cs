using IMD.VideoLibrary.Repository.Interfaces;

using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.Repository
{
    /// <summary>
    /// Unity container extension for Repository Layer
    /// </summary>
    public class RepositoryUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<IVideoReelRepository, VideoReelRepository>(new HierarchicalLifetimeManager());
            this.Container.RegisterType<IVideoClipRepository, VideoClipRepository>(new HierarchicalLifetimeManager());
            this.Container.RegisterType<IReelClipLinkRepository, ReelClipLinkRepository>(new HierarchicalLifetimeManager());
        }
    }
}
