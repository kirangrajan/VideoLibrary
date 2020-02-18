using IMD.VideoLibrary.BusinessLogic;
using IMD.VideoLibrary.Repository;
using IMD.VideoLibrary.UI.Common;
using IMD.VideoLibrary.ViewModel;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System.Web.Mvc;

namespace IMD.VideoLibrary.UI
{
    /// <summary>
    /// Boot strapper class
    /// </summary>
    public class BootStrapper
    {
        private readonly IUnityContainer _container;

        public BootStrapper()
        {
            this._container = new UnityContainer();
        }

        public IUnityContainer Run()
        {
            this._container.AddNewExtension<BusinessLogicUnityExtension>();
            this._container.AddNewExtension<RepositoryUnityExtension>();
            this._container.AddNewExtension<ViewModelUnityExtension>();
            this._container.AddNewExtension<UIUnityExtension>();

            
            MvcUnityContainer.Container = this._container;
            DependencyResolver.SetResolver(new UnityDependencyResolver(_container));

            return this._container;
        }
    }
}