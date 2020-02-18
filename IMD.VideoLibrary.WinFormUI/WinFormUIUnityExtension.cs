using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.WinFormUI
{
    /// <summary>
    /// Unity container extension for Winform UI
    /// </summary>
    public class WinFormUIUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.RegisterViews();
            this.RegisterViewModels();
        }

        private void RegisterViews()
        {
        }

        private void RegisterViewModels()
        {
        }
    }
}
