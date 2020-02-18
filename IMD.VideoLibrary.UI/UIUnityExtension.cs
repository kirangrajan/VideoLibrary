using IMD.VideoLibrary.UI.Controllers;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace IMD.VideoLibrary.UI
{
    public class UIUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            this.Container.RegisterType<IController, HomeController>("Home");
        }
    }
}