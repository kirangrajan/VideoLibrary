using IMD.VideoLibrary.ViewModel.Interfaces;

using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.ViewModel
{
    public class ViewModelUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<IVideoReelAddViewModel, VideoReelAddViewModel>(new HierarchicalLifetimeManager());
            this.Container.RegisterType<IVideoReelListViewModel, VideoReelListViewModel>(new HierarchicalLifetimeManager());
        }
    }
}
