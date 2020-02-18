using Microsoft.Practices.Unity;

namespace IMD.VideoLibrary.UI.Common
{
    /// <summary>
    /// Unity container for ASP.net MVC
    /// </summary>
    public class MvcUnityContainer
    {
        public static IUnityContainer Container { get; set; }
    }
}